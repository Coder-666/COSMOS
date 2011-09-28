using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Debugger.Interop;
using Cosmos.Debug.Common;

namespace Cosmos.Debug.VSDebugEngine
{
    // An implementation of IDebugProperty2
    // This interface represents a stack frame property, a program document property, or some other property. 
    // The property is usually the result of an expression evaluation. 
    //
    // The sample engine only supports locals and parameters for functions that have symbols loaded.
    class AD7Property : IDebugProperty2
    {
        private DebugLocalInfo m_variableInformation;
        private AD7Process mProcess;
        private AD7StackFrame mStackFrame;
        private DebugInfo.Local_Argument_Info mDebugInfo;


        public AD7Property(DebugLocalInfo localInfo, AD7Process process, AD7StackFrame stackFrame)
        {
            m_variableInformation = localInfo;
            mProcess = process;
            mStackFrame = stackFrame;
            if (localInfo.IsLocal)
            {
                mDebugInfo = mStackFrame.mLocalInfos[m_variableInformation.Index];
            }
            else
            {
                mDebugInfo = mStackFrame.mArgumentInfos[m_variableInformation.Index];
            }
        }

        // Construct a DEBUG_PROPERTY_INFO representing this local or parameter.
        public DEBUG_PROPERTY_INFO ConstructDebugPropertyInfo(enum_DEBUGPROP_INFO_FLAGS dwFields)
        {
            DEBUG_PROPERTY_INFO propertyInfo = new DEBUG_PROPERTY_INFO();

            if (dwFields.HasFlag(enum_DEBUGPROP_INFO_FLAGS.DEBUGPROP_INFO_FULLNAME))
            {
                propertyInfo.bstrFullName = m_variableInformation.Name;
                propertyInfo.dwFields |= enum_DEBUGPROP_INFO_FLAGS.DEBUGPROP_INFO_FULLNAME;
            }

            if (dwFields.HasFlag(enum_DEBUGPROP_INFO_FLAGS.DEBUGPROP_INFO_NAME))
            {
                propertyInfo.bstrName = m_variableInformation.Name;
                propertyInfo.dwFields |= enum_DEBUGPROP_INFO_FLAGS.DEBUGPROP_INFO_NAME;
            }

            if (dwFields.HasFlag(enum_DEBUGPROP_INFO_FLAGS.DEBUGPROP_INFO_TYPE))
            {
                propertyInfo.bstrType = mDebugInfo.Type;
                propertyInfo.dwFields |= enum_DEBUGPROP_INFO_FLAGS.DEBUGPROP_INFO_TYPE;
            }

            if (dwFields.HasFlag(enum_DEBUGPROP_INFO_FLAGS.DEBUGPROP_INFO_VALUE))
            {
                byte[] xData;

                #region String
                if (mDebugInfo.Type == typeof(string).AssemblyQualifiedName)
                {
                    const uint xStringLengthOffset = 12;
                    const uint xStringFirstCharOffset = 16;
                    xData = mProcess.mDbgConnector.GetStackData(mDebugInfo.Offset, 4);
                    uint xStrPointer = BitConverter.ToUInt32(xData, 0);
                    if (xStrPointer == 0)
                    {
                        propertyInfo.bstrValue = "(null)";
                    }
                    else
                    {
                        xData = mProcess.mDbgConnector.GetMemoryData(xStrPointer + xStringLengthOffset, 4, 4);
                        uint xStringLength = BitConverter.ToUInt32(xData, 0);
                        propertyInfo.bstrValue = "String of length: " + xStringLength;
                        if (xStringLength > 100)
                        {
                            propertyInfo.bstrValue = "For now, strings larger than 100 chars are not supported..";
                        }
                        else if (xStringLength == 0)
                        {
                            propertyInfo.bstrValue = "\"\"";
                        }
                        else
                        {
                            xData = mProcess.mDbgConnector.GetMemoryData(xStrPointer + xStringFirstCharOffset, xStringLength * 2, 2);
                            propertyInfo.bstrValue = "\"" + Encoding.Unicode.GetString(xData) + "\"";
                        }
                    }
                }
#warning TODO: String[]
                #endregion

                #region Byte
#warning TODO: Byte
                else if (mDebugInfo.Type == typeof(byte[]).AssemblyQualifiedName)
                {
                    const uint xArrayLengthOffset = 8;
                    const uint xArrayFirstElementOffset = 16;
                    xData = mProcess.mDbgConnector.GetStackData(mDebugInfo.Offset, 4);
                    uint xArrayPointer = BitConverter.ToUInt32(xData, 0);
                    if (xArrayPointer == 0)
                    {
                        propertyInfo.bstrValue = "(null)";
                    }
                    else
                    {
                        xData = mProcess.mDbgConnector.GetMemoryData(xArrayPointer + xArrayLengthOffset, 4, 4);
                        uint xDataLength = BitConverter.ToUInt32(xData, 0);
                        bool xIsTooLong = xDataLength > 512;
                        var xSB = new StringBuilder();
                        xSB.AppendFormat("Byte[{0}] at 0x{1} {{ ", xDataLength, xArrayPointer.ToString("X"));
                        if (xIsTooLong)
                        {
                            xDataLength = 512;
                        }
                        if (xDataLength > 0)
                        {
                            xData = mProcess.mDbgConnector.GetMemoryData(xArrayPointer + xArrayFirstElementOffset, xDataLength);
                            for (int i = 0; i < xData.Length; i++)
                            {
                                xSB.Append(xData[i].ToString("X2").ToUpper());
                                if (i < (xData.Length - 1))
                                {
                                    xSB.Append(" ");
                                }
                            }
                        }
                        if (xIsTooLong)
                        {
                            xSB.Append(", ..");
                        }

                        xSB.Append(" }");
                        propertyInfo.bstrValue = xSB.ToString();
                    }
                }
                #endregion

                #region Char
                else if (mDebugInfo.Type == typeof(char).AssemblyQualifiedName)
                {
                    xData = mProcess.mDbgConnector.GetStackData(mDebugInfo.Offset, 2);
                    var xTypedCharValue = BitConverter.ToChar(xData, 0);
                    propertyInfo.bstrValue = String.Format("{0} '{1}'", (ushort)xTypedCharValue, xTypedCharValue);
                }
                else if (mDebugInfo.Type == typeof(char[]).AssemblyQualifiedName)
                {
                    xData = mProcess.mDbgConnector.GetStackData(mDebugInfo.Offset, 4);

                    const uint OFFSET_LENGTH = 8;
                    const uint OFFSET_FROM_LENGTH_TO_DATA = 8;
                    uint pointer = BitConverter.ToUInt32(xData, 0);
					if (pointer == 0)
					{
						propertyInfo.bstrValue = "(null)";
					}
					else
					{
						StringBuilder b = new StringBuilder();

						b.Append(String.Format("(Address 0x{0});", pointer.ToString("X").ToUpper()));

						pointer += OFFSET_LENGTH;
						xData = mProcess.mDbgConnector.GetMemoryData(pointer, 4);
						int size = BitConverter.ToInt32(xData, 0);

						b.Append("Count: ");
						b.Append(size);
						b.Append("; ");

						for (int i = 0; i < size; i++)
						{
							xData = mProcess.mDbgConnector.GetMemoryData((uint)(pointer + OFFSET_FROM_LENGTH_TO_DATA + i * sizeof(char)), 2);
							char c = BitConverter.ToChar(xData, 0);


							b.Append('\'');
							if (c == '\0')
							{
								b.Append("\\0");
							}
							else
							{
								b.Append(c);
							}
							b.Append('\'');
							if (i - 1 < size)
								b.Append(' ');
						}
						propertyInfo.bstrValue = b.ToString();
					}
                }
                #endregion

                #region Int32
                else if (mDebugInfo.Type == typeof(int).AssemblyQualifiedName)
                {
                    xData = mProcess.mDbgConnector.GetStackData(mDebugInfo.Offset, 4);
                    var xTypedIntValue = BitConverter.ToInt32(xData, 0);
                    propertyInfo.bstrValue = String.Format("{0} (0x{1})", xTypedIntValue, xTypedIntValue.ToString("X").ToUpper());
                }
                else if (mDebugInfo.Type == typeof(int[]).AssemblyQualifiedName)
                {
                    StringBuilder b = new StringBuilder();
                    xData = mProcess.mDbgConnector.GetStackData(mDebugInfo.Offset, 4);

                    const uint OFFSET_LENGTH = 8;
                    const uint OFFSET_FROM_LENGTH_TO_DATA = 8;
                    uint pointer = BitConverter.ToUInt32(xData, 0);
                    pointer += OFFSET_LENGTH;
                    xData = mProcess.mDbgConnector.GetMemoryData(pointer, 4);
                    int size = BitConverter.ToInt32(xData, 0);

                    b.Append("Count: ");
                    b.Append(size);
                    b.Append("; ");

                    for (int i = 0; i < size; i++)
                    {
                        xData = mProcess.mDbgConnector.GetMemoryData((uint)(pointer + OFFSET_FROM_LENGTH_TO_DATA + i * sizeof(char)), 2);
                        Int32 intdata = BitConverter.ToInt32(xData, 0);

                        b.Append('\'');
                        b.Append(intdata.ToString("X").ToUpper());
                        b.Append('\'');
                        if (i - 1 < size)
                            b.Append(' ');
                    }
                    propertyInfo.bstrValue = b.ToString();
                }
                #endregion

                #region Long
                else if (mDebugInfo.Type == typeof(long).AssemblyQualifiedName)
                {
                    xData = mProcess.mDbgConnector.GetStackData(mDebugInfo.Offset, 8);
                    if (xData.Length != 8)
                    {
                        throw new Exception("Length should have been 8, but is " + xData.Length);
                    }
                    var xTypedLongValue = BitConverter.ToInt64(xData, 0);
                    propertyInfo.bstrValue = String.Format("{0} (0x{1})", xTypedLongValue, xTypedLongValue.ToString("X").ToUpper());
                }
#warning TODO: Long[]
                #endregion

                #region ULong
                else if (mDebugInfo.Type == typeof(ulong).AssemblyQualifiedName)
                {
                    xData = mProcess.mDbgConnector.GetStackData(mDebugInfo.Offset, 8);
                    if (xData.Length != 8)
                    {
                        throw new Exception("Length should have been 8, but is " + xData.Length);
                    }
                    var xTypedULongValue = BitConverter.ToUInt64(xData, 0);
                    propertyInfo.bstrValue = String.Format("{0} (0x{1})", xTypedULongValue, xTypedULongValue.ToString("X").ToUpper());
                }
#warning TODO: ULong[]
                #endregion

                #region Float
                else if (mDebugInfo.Type == typeof(float).AssemblyQualifiedName)
                {
                    xData = mProcess.mDbgConnector.GetStackData(mDebugInfo.Offset, 4);
                    if (xData.Length != 4)
                    {
                        throw new Exception("Length should have been 4, but is " + xData.Length);
                    }
                    var xTypedFloatValue = BitConverter.ToSingle(xData, 0);
                    var xTypedFloatHexValue = BitConverter.ToUInt32(xData, 0);
                    propertyInfo.bstrValue = String.Format("{0} (0x{1})", xTypedFloatValue, xTypedFloatHexValue.ToString("X").ToUpper());
                }
#warning TODO: Float[]
                #endregion

                #region Double
                else if (mDebugInfo.Type == typeof(double).AssemblyQualifiedName)
                {
                    xData = mProcess.mDbgConnector.GetStackData(mDebugInfo.Offset, 8);
                    if (xData.Length != 8)
                    {
                        throw new Exception("Length should have been 8, but is " + xData.Length);
                    }
                    var xTypedDoubleValue = BitConverter.ToDouble(xData, 0);
                    var xTypedDoubleHexValue = BitConverter.ToUInt64(xData, 0);
                    propertyInfo.bstrValue = String.Format("{0} (0x{1})", xTypedDoubleValue, xTypedDoubleHexValue.ToString("X").ToUpper());
                }
#warning TODO: Double[]
                #endregion

                #region Bool
                else if (mDebugInfo.Type == typeof(bool).AssemblyQualifiedName)
                {
                    xData = mProcess.mDbgConnector.GetStackData(mDebugInfo.Offset, 4);
                    var xTypedBoolValue = BitConverter.ToBoolean(xData, 0);
                    var xTypedUIntValue = BitConverter.ToUInt32(xData, 0);
                    propertyInfo.bstrValue = String.Format("{0} (0x{1})", xTypedBoolValue.ToString(), xTypedUIntValue.ToString("X").ToUpper());
                }
#warning TODO: Bool[]
                #endregion

                else
                {
                    xData = mProcess.mDbgConnector.GetStackData(mDebugInfo.Offset, 4);
                    var xTypedUIntValue = BitConverter.ToUInt32(xData, 0);
                    propertyInfo.bstrValue = String.Format("{0} (0x{1})", xTypedUIntValue, xTypedUIntValue.ToString("X").ToUpper());
                }
                propertyInfo.dwFields |= enum_DEBUGPROP_INFO_FLAGS.DEBUGPROP_INFO_VALUE;
            }

            if (dwFields.HasFlag(enum_DEBUGPROP_INFO_FLAGS.DEBUGPROP_INFO_ATTRIB))
            {
                // The sample does not support writing of values displayed in the debugger, so mark them all as read-only.
                propertyInfo.dwAttrib = enum_DBG_ATTRIB_FLAGS.DBG_ATTRIB_VALUE_READONLY;

                //if (this.m_variableInformation.child != null)
                {
                    //propertyInfo.dwAttrib |= DBG_ATTRIB_FLAGS.DBG_ATTRIB_OBJ_IS_EXPANDABLE;
                }
            }

            // If the debugger has asked for the property, or the property has children (meaning it is a pointer in the sample)
            // then set the pProperty field so the debugger can call back when the chilren are enumerated.
            //if (((dwFields & (uint)enum_DEBUGPROP_INFO_FLAGS.DEBUGPROP_INFO_PROP) != 0) 
            //|| (this.m_variableInformation.child != null))
            {
                //propertyInfo.pProperty = (IDebugProperty2)this;
                //propertyInfo.dwFields |= (uint)(DEBUGPROP_INFO_FLAGS.DEBUGPROP_INFO_PROP);
            }

            return propertyInfo;
        }

        #region IDebugProperty2 Members

        // Enumerates the children of a property. This provides support for dereferencing pointers, displaying members of an array, or fields of a class or struct.
        // The sample debugger only supports pointer dereferencing as children. This means there is only ever one child.
        public int EnumChildren(enum_DEBUGPROP_INFO_FLAGS dwFields, uint dwRadix, ref System.Guid guidFilter, enum_DBG_ATTRIB_FLAGS dwAttribFilter, string pszNameFilter, uint dwTimeout, out IEnumDebugPropertyInfo2 ppEnum)
        {
            ppEnum = null;

            //if (this.m_variableInformation.child != null)
            //{
            //    DEBUG_PROPERTY_INFO[] properties = new DEBUG_PROPERTY_INFO[1];
            //    properties[0] = (new AD7Property(this.m_variableInformation.child)).ConstructDebugPropertyInfo(dwFields);
            //    ppEnum = new AD7PropertyEnum(properties);
            //    return VSConstants.S_OK;
            //}

            return VSConstants.S_FALSE;
        }

        // Returns the property that describes the most-derived property of a property
        // This is called to support object oriented languages. It allows the debug engine to return an IDebugProperty2 for the most-derived 
        // object in a hierarchy. This engine does not support this.
        public int GetDerivedMostProperty(out IDebugProperty2 ppDerivedMost)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        // This method exists for the purpose of retrieving information that does not lend itself to being retrieved by calling the IDebugProperty2::GetPropertyInfo 
        // method. This includes information about custom viewers, managed type slots and other information.
        // The sample engine does not support this.
        public int GetExtendedInfo(ref System.Guid guidExtendedInfo, out object pExtendedInfo)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        // Returns the memory bytes for a property value.
        public int GetMemoryBytes(out IDebugMemoryBytes2 ppMemoryBytes)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        // Returns the memory context for a property value.
        public int GetMemoryContext(out IDebugMemoryContext2 ppMemory)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        // Returns the parent of a property.
        // The sample engine does not support obtaining the parent of properties.
        public int GetParent(out IDebugProperty2 ppParent)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        // Fills in a DEBUG_PROPERTY_INFO structure that describes a property.
        public int GetPropertyInfo(enum_DEBUGPROP_INFO_FLAGS dwFields, uint dwRadix, uint dwTimeout, IDebugReference2[] rgpArgs, uint dwArgCount, DEBUG_PROPERTY_INFO[] pPropertyInfo)
        {
            pPropertyInfo[0] = new DEBUG_PROPERTY_INFO();
            rgpArgs = null;
            pPropertyInfo[0] = ConstructDebugPropertyInfo(dwFields);
            return VSConstants.S_OK;
        }

        //  Return an IDebugReference2 for this property. An IDebugReference2 can be thought of as a type and an address.
        public int GetReference(out IDebugReference2 ppReference)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        // Returns the size, in bytes, of the property value.
        public int GetSize(out uint pdwSize)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        // The debugger will call this when the user tries to edit the property's values
        // the sample has set the read-only flag on its properties, so this should not be called.
        public int SetValueAsReference(IDebugReference2[] rgpArgs, uint dwArgCount, IDebugReference2 pValue, uint dwTimeout)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        // The debugger will call this when the user tries to edit the property's values in one of the debugger windows.
        // the sample has set the read-only flag on its properties, so this should not be called.
        public int SetValueAsString(string pszValue, uint dwRadix, uint dwTimeout)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

    }
}

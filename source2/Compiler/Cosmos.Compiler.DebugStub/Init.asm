DebugBPs TIMES 256 dd 0
DebugWaitMsg db "Waiting for debugger connection..."



DebugStub_Init:
Call DebugStub_Cls
Call DebugStub_DisplayWaitMsg
Call DebugStub_InitSerial
Call DebugStub_WaitForDbgHandshake
Call DebugStub_Cls
DebugStub_Init_Exit:
Ret

DebugStub_WaitForSignature:
Mov EBX, 0
DebugStub_WaitForSignature_Read:
Call DebugStub_ComReadAL
Mov BL, AL
ROR EBX, 8
Cmp EBX, DebugStub_Const_Signature
JNE DebugStub_WaitForSignature_Read
DebugStub_WaitForSignature_Exit:
Ret

DebugStub_WaitForDbgHandshake:
Mov AL, 0
Call DebugStub_ComWriteAL

Push dword DebugStub_Const_Signature
Mov ESI, ESP

Call DebugStub_ComWrite32

Pop EAX

Mov AL, DebugStub_Const_Ds2Vs_Started
Call DebugStub_ComWriteAL

Call DebugStub_WaitForSignature
Call DebugStub_ProcessCommandBatch
DebugStub_WaitForDbgHandshake_Exit:
Ret



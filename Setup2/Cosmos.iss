; Cosmos Registry key
; Install assemblies
; Delete old user kit installer and task asm

[Setup]
AppName=Cosmos User Kit
AppVerName=Cosmos User Kit Milestone 5
AppCopyright=Copyright � 2007-2010 The Cosmos Project
AppPublisher=Cosmos Project
AppPublisherURL=http://www.gocosmos.org/
AppSupportURL=http://www.gocosmos.org/
AppUpdatesURL=http://www.gocosmos.org/
DefaultDirName={userappdata}\Cosmos User Kit
DefaultGroupName=Cosmos User Kit
OutputDir=.\Setup2\Output
OutputBaseFilename=CosmosUserKit5
Compression=lzma/fast
SolidCompression=true
SourceDir=..
;Left Image should be 164x314
WizardImageFile=.\setup\images\cosmos.bmp
;Small Image should be 55x55
WizardSmallImageFile=.\setup\images\cosmos_small.bmp

; If you want all languages to be listed in the "Select Setup Language"
; dialog, even those that can't be displayed in the active code page,
; uncomment the following two lines.
InternalCompressLevel=fast
UninstallLogMode=overwrite

#include "Code.inc"

[LangOptions]
LanguageCodePage=0

[Languages]
Name: en; MessagesFile: compiler:Default.isl; InfoBeforeFile: .\setup\Readme.txt
;Name: eu; MessagesFile: "..\setup\Languages\Basque-1-5.1.0.isl"; InfoBeforeFile: "..\setup\Readme.txt"
;Name: ca; MessagesFile: "..\setup\Languages\Catalan-4-5.1.0.isl"; InfoBeforeFile: "..\setup\Readme.txt"
;Name: cs; MessagesFile: "..\setup\Languages\Czech-5-5.1.0.isl"; InfoBeforeFile: "..\setup\Readme.txt"
;Name: da; MessagesFile: "..\setup\Languages\Danish-4-5.1.0.isl"; InfoBeforeFile: "..\setup\Readme.txt"
;Name: nl; MessagesFile: "..\setup\Languages\Dutch-8-5.1.0.isl"; InfoBeforeFile: "..\setup\Readme.txt"
;Name: fi; MessagesFile: "..\setup\Languages\Finnish-5.1.0.isl"; InfoBeforeFile: "..\setup\Readme.txt"
;Name: fr; MessagesFile: "..\setup\Languages\French-15-5.1.0.isl"; InfoBeforeFile: "..\setup\Readme.txt"
;Name: de; MessagesFile: "..\setup\Languages\German-2-5.1.0.isl"; InfoBeforeFile: "..\setup\Readme.txt"
;Name: hu; MessagesFile: "..\setup\Languages\Hungarian-5.1.0.isl"; InfoBeforeFile: "..\setup\Readme.txt"
;Name: it; MessagesFile: "..\setup\Languages\Italian-14-5.1.0.isl"; InfoBeforeFile: "..\setup\Readme.txt"
;Name: no; MessagesFile: "..\setup\Languages\Norwegian-5.1.0.isl"; InfoBeforeFile: "..\setup\Readme.txt"
;Name: pl; MessagesFile: "..\setup\Languages\Polish-8-5.1.0.isl"; InfoBeforeFile: "..\setup\Readme.txt"
;Name: pt; MessagesFile: "..\setup\Languages\PortugueseStd-1-5.1.0.isl"; InfoBeforeFile: "..\setup\Readme.txt"
;Name: ru; MessagesFile: "..\setup\Languages\Russian-19-5.1.0.isl"; InfoBeforeFile: "..\setup\Readme.txt"
;Name: sk; MessagesFile: "..\setup\Languages\Slovak-6-5.1.0.isl"; InfoBeforeFile: "..\setup\Readme.txt"
;Name: sl; MessagesFile: "..\setup\Languages\Slovenian-3-5.1.0.isl"; InfoBeforeFile: "..\setup\Readme.txt"
;;InOffical:
;Name: bg; MessagesFile: "..\setup\Languages\InOfficial\Bulgarian-5.1.0.isl"; InfoBeforeFile: "..\setup\Readme.txt"
;Name: el; MessagesFile: "..\setup\Languages\InOfficial\Greek-4-5.1.0.isl"; InfoBeforeFile: "..\setup\Readme.txt"
;Name: is; MessagesFile: "..\setup\Languages\InOfficial\Icelandic-1-5.1.0.isl"; InfoBeforeFile: "..\setup\Readme.txt"
;Name: id; MessagesFile: "..\setup\Languages\InOfficial\Indonesian-5.1.0.isl"; InfoBeforeFile: "..\setup\Readme.txt"
;Name: ja; MessagesFile: "..\setup\Languages\InOfficial\Japanese-5-5.1.0.isl"; InfoBeforeFile: "..\setup\Readme.txt"
;Name: ko; MessagesFile: "..\setup\Languages\InOfficial\Korean-5-5.1.0.isl"; InfoBeforeFile: "..\setup\Readme.txt"
;Name: ms; MessagesFile: "..\setup\Languages\InOfficial\Malaysian-2-5.1.0.isl"; InfoBeforeFile: "..\setup\Readme.txt"
;Name: es; MessagesFile: "..\setup\Languages\InOfficial\SpanishStd-2-5.1.0.isl"; InfoBeforeFile: "..\setup\Readme.txt"
;Name: sv; MessagesFile: "..\setup\Languages\InOfficial\Swedish-8-5.1.0.isl"; InfoBeforeFile: "..\setup\Readme.txt"
;Name: tr; MessagesFile: "..\setup\Languages\InOfficial\Turkish-3-5.1.0.isl"; InfoBeforeFile: "..\setup\Readme.txt"
;Name: uk; MessagesFile: "..\setup\Languages\InOfficial\Ukrainian-5-5.1.0.isl"; InfoBeforeFile: "..\setup\Readme.txt"
;Name: cn; MessagesFile: "..\setup\Languages\InOfficial\ChineseSimp-11-5.1.0.isl"; InfoBeforeFile: "..\setup\Readme.txt"
;Name: tw; MessagesFile: "..\setup\Languages\InOfficial\ChineseTrad-2-5.1.0.isl"; InfoBeforeFile: "..\setup\Readme.txt"

[Messages]
en.BeveledLabel=English
;eu.BeveledLabel=Basque
;ca.BeveledLabel=Catalan
;cs.BeveledLabel=Czech
;da.BeveledLabel=Danish
;nl.BeveledLabel=Dutch
;fi.BeveledLabel=Finnish
;fr.BeveledLabel=French
;de.BeveledLabel=German
;hu.BeveledLabel=Hungarian
;it.BeveledLabel=Italian
;no.BeveledLabel=Norwegian
;pl.BeveledLabel=Polish
;pt.BeveledLabel=Portuguese
;ru.BeveledLabel=Russian
;sk.BeveledLabel=Slovak
;sl.BeveledLabel=Slovenian
;;InOffical:
;bg.BeveledLabel=Bulgarian
;el.BeveledLabel=Greek
;is.BeveledLabel=Icelandic
;id.BeveledLabel=Indonesian
;ja.BeveledLabel=Japanese
;ko.BeveledLabel=Korean
;ms.BeveledLabel=Malaysian
;es.BeveledLabel=Spanish
;sv.BeveledLabel=Swedish
;tr.BeveledLabel=Turkish
;uk.BeveledLabel=Ukrainian
;cn.BeveledLabel=Chinese Simplified
;tw.BeveledLabel=Chinese Traditional

[Dirs]
Name: "{code:VSNET2008_PATH|}\ProjectTemplates\Cosmos"; Flags: uninsalwaysuninstall

[Files]
Source: .\Build\Tools\*.exe; DestDir: {app}\Build\Tools
Source: .\Build\Tools\NAsm\*.exe; DestDir: {app}\Build\Tools\NAsm
Source: .\Build\Tools\Qemu\*; DestDir: {app}\Build\Tools\Qemu; Flags: recursesubdirs createallsubdirs
Source: .\Build\Tools\Cygwin\*; DestDir: {app}\Build\Tools\cygwin
Source: .\Build\Tools\Cosmos.Hardware\*; DestDir: {app}\Build\Tools\Cosmsos.Hardware; Flags: recursesubdirs createallsubdirs
Source: .\Build\Tools\Cosmos.Hardware.Plugs\*; DestDir: {app}\Build\Tools\Cosmsos.Hardware.Plugs; Flags: recursesubdirs createallsubdirs
Source: .\Build\Tools\Cosmos.Kernel.Plugs\*; DestDir: {app}\Build\Tools\Cosmsos.Kernel.Plugs; Flags: recursesubdirs createallsubdirs
Source: .\Build\Tools\Cosmos.Sys.Plugs\*; DestDir: {app}\Build\Tools\Cosmsos.Sys.Plugs; Flags: recursesubdirs createallsubdirs
Source: .\Build\VSIP\*; DestDir: {app}\Build\VSIP\; Flags: recursesubdirs createallsubdirs
Source: .\source\libraries\MDbg\raw.dll; DestDir: {app}\Build\VSIP\;
Source: .\Build\VSIP\Cosmos.targets; DestDir: {pf32}\MSBuild\Cosmos;
Source: .\source\Cosmos\Cosmos.Kernel\bin\x86\Debug\Cosmos.Kernel.*; DestDir: {app}\Kernel;
Source: .\source\Cosmos\Cosmos.System\bin\x86\Debug\Cosmos.Hardware.*; DestDir: {app}\Kernel;
Source: .\source\Cosmos\Cosmos.System\bin\x86\Debug\Cosmos.Sys.*; DestDir: {app}\Kernel;
Source: .\source\Cosmos\Cosmos.System\bin\x86\Debug\Cosmos.Sys.FileSystem.*; DestDir: {app}\Kernel;
Source: .\Build\VSIP\CosmosProject.zip; DestDir: {code:VSNET2008_PATH|}\ProjectTemplates\Cosmos;

; gac-ed assemblies:
Source: .\Build\VSIP\Cosmos.Build.Common.dll;         DestDir: {app}\Build\GAC; StrongAssemblyName: "Cosmos.Build.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=5ae71220097cb983, ProcessorArchitecture=MSIL"; Flags: gacinstall
Source: .\Build\VSIP\Cosmos.Debug.Common.dll;         DestDir: {app}\Build\GAC; StrongAssemblyName: "Cosmos.Debug.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=5ae71220097cb983, ProcessorArchitecture=MSIL"; Flags: gacinstall
Source: .\Build\VSIP\Cosmos.Compiler.Debug.dll;       DestDir: {app}\Build\GAC; StrongAssemblyName: "Cosmos.Compiler.Debug, Version=1.0.0.0, Culture=neutral, PublicKeyToken=5ae71220097cb983, ProcessorArchitecture=MSIL"; Flags: gacinstall
Source: .\Build\VSIP\Cosmos.Debug.VSDebugEngine.dll;  DestDir: {app}\Build\GAC; StrongAssemblyName: "Cosmos.Debug.VSDebugEngine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=5ae71220097cb983, ProcessorArchitecture=MSIL"; Flags: gacinstall
Source: .\Build\VSIP\corapi.dll;                      DestDir: {app}\Build\GAC; StrongAssemblyName: "corapi, Version=2.1.0.0, Culture=neutral, PublicKeyToken=ebb8d478f63174c0, ProcessorArchitecture=MSIL"; Flags: gacinstall
Source: .\Build\VSIP\raw.dll;                         DestDir: {app}\Build\GAC; StrongAssemblyName: "raw, Version=2.1.0.0, Culture=neutral, PublicKeyToken=ebb8d478f63174c0, ProcessorArchitecture=MSIL"; Flags: gacinstall
Source: .\Build\VSIP\Cosmos.VS.Package.dll;           DestDir: {app}\Build\GAC; StrongAssemblyName: "Cosmos.VS.Package, Version=1.0.0.0, Culture=neutral, PublicKeyToken=f4d94ac959d59ec3, ProcessorArchitecture=MSIL"; Flags: gacinstall

;Source: ".\Build\Tools\*"; DestDir: "{app}\Build\Tools"; Excludes: "*.log;*.asm;output.bin;output.o;output.obj;output.map;cosmos.iso"; Flags: recursesubdirs createallsubdirs;
;Source: ".\Build\VSIP\*"; DestDir: "{app}\Build\VSIP"; Excludes: "*.pkgdef"; Flags: recursesubdirs createallsubdirs;



[Registry]
Root: HKLM; Subkey: Software\Microsoft\.NETFramework\v2.0.50727\AssemblyFoldersEx\Cosmos; ValueType: none; Flags: uninsdeletekey
Root: HKLM; Subkey: Software\Microsoft\.NETFramework\v2.0.50727\AssemblyFoldersEx\Cosmos; ValueType: string; ValueName: ; ValueData: {app}\Kernel\; Flags: uninsdeletevalue

Root: HKLM; Subkey: Software\Microsoft\VisualStudio\9.0\InstalledProducts\Cosmos Visual Studio Integration Package; ValueType: none; Flags: uninsdeletekey
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\InstalledProducts\Cosmos Visual Studio Integration Package; ValueType: string; ValueName: ; ValueData: Cosmos Visual Studio Integration Package; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\InstalledProducts\Cosmos Visual Studio Integration Package; ValueType: dword; ValueName: UseRegNameAsSplashName; ValueData: $00000001; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\InstalledProducts\Cosmos Visual Studio Integration Package; ValueType: string; ValueName: ProductDetails; ValueData: www.gocosmos.org; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\InstalledProducts\Cosmos Visual Studio Integration Package; ValueType: string; ValueName: PID; ValueData: 1.0; Flags: uninsdeletevalue uninsdeletekeyifempty

Root: HKLM; Subkey: Software\Microsoft\VisualStudio\9.0\Packages\{{4cae44ed-88b9-4b7c-822b-b040f18fcee3}; ValueType: none; Flags: uninsdeletekey
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\Packages\{{4cae44ed-88b9-4b7c-822b-b040f18fcee3}; ValueType: string; ValueName: ; ValueData: Cosmos.VS.Package.VSProject, Cosmos.VS.Package, Version=1.0.0.0, Culture=neutral, PublicKeyToken=f4d94ac959d59ec3; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\Packages\{{4cae44ed-88b9-4b7c-822b-b040f18fcee3}; ValueType: string; ValueName: InprocServer32; ValueData: C:\Windows\SYSTEM32\MSCOREE.DLL; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\Packages\{{4cae44ed-88b9-4b7c-822b-b040f18fcee3}; ValueType: string; ValueName: Class; ValueData: Cosmos.VS.Package.VSProject; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\Packages\{{4cae44ed-88b9-4b7c-822b-b040f18fcee3}; ValueType: string; ValueName: Assembly; ValueData: Cosmos.VS.Package, Version=1.0.0.0, Culture=neutral, PublicKeyToken=f4d94ac959d59ec3; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\Packages\{{4cae44ed-88b9-4b7c-822b-b040f18fcee3}; ValueType: dword; ValueName: ID; ValueData: $000003E9; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\Packages\{{4cae44ed-88b9-4b7c-822b-b040f18fcee3}; ValueType: string; ValueName: MinEdition; ValueData: Standard; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\Packages\{{4cae44ed-88b9-4b7c-822b-b040f18fcee3}; ValueType: string; ValueName: ProductVersion; ValueData: 1.0; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\Packages\{{4cae44ed-88b9-4b7c-822b-b040f18fcee3}; ValueType: string; ValueName: ProductName; ValueData: Cosmos Visual Studio Integration Package; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\Packages\{{4cae44ed-88b9-4b7c-822b-b040f18fcee3}; ValueType: string; ValueName: CompanyName; ValueData: Cosmos; Flags: uninsdeletevalue uninsdeletekeyifempty

Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\CLSID\{{d33a2d29-c4fd-4e12-a510-4c01a14d63e1}; ValueType: none; Flags: uninsdeletekey
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\CLSID\{{d33a2d29-c4fd-4e12-a510-4c01a14d63e1}; ValueType: string; ValueName: ; ValueData: Cosmos.VS.Package.BuildOptionsPropertyPage; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\CLSID\{{d33a2d29-c4fd-4e12-a510-4c01a14d63e1}; ValueType: string; ValueName: InprocServer32; ValueData: C:\Windows\SYSTEM32\MSCOREE.DLL; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\CLSID\{{d33a2d29-c4fd-4e12-a510-4c01a14d63e1}; ValueType: string; ValueName: Class; ValueData: Cosmos.VS.Package.BuildOptionsPropertyPage; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\CLSID\{{d33a2d29-c4fd-4e12-a510-4c01a14d63e1}; ValueType: string; ValueName: CodeBase; ValueData: {app}\build\vsip\Cosmos.VS.Package.dll; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\CLSID\{{d33a2d29-c4fd-4e12-a510-4c01a14d63e1}; ValueType: string; ValueName: ThreadingModel; ValueData: Both; Flags: uninsdeletevalue uninsdeletekeyifempty

Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\CLSID\{{39801176-289f-405f-9425-2931a2c03912}; ValueType: none; Flags: uninsdeletekey
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\CLSID\{{39801176-289f-405f-9425-2931a2c03912}; ValueType: string; ValueName: ; ValueData: Cosmos.VS.Package.DebugOptionsPropertyPage; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\CLSID\{{39801176-289f-405f-9425-2931a2c03912}; ValueType: string; ValueName: InprocServer32; ValueData: C:\Windows\SYSTEM32\MSCOREE.DLL; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\CLSID\{{39801176-289f-405f-9425-2931a2c03912}; ValueType: string; ValueName: Class; ValueData: Cosmos.VS.Package.DebugOptionsPropertyPage; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\CLSID\{{39801176-289f-405f-9425-2931a2c03912}; ValueType: string; ValueName: CodeBase; ValueData: {app}\build\vsip\Cosmos.VS.Package.dll; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\CLSID\{{39801176-289f-405f-9425-2931a2c03912}; ValueType: string; ValueName: ThreadingModel; ValueData: Both; Flags: uninsdeletevalue uninsdeletekeyifempty deletekey deletevalue; Languages: 

Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\CLSID\{{3b72bb68-7363-45a2-9eba-55c8d5f36e36}; ValueType: none; Flags: uninsdeletekey
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\CLSID\{{3b72bb68-7363-45a2-9eba-55c8d5f36e36}; ValueType: string; ValueName: ; ValueData: Cosmos.VS.Package.VMOptionsPropertyPage; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\CLSID\{{3b72bb68-7363-45a2-9eba-55c8d5f36e36}; ValueType: string; ValueName: InprocServer32; ValueData: C:\Windows\SYSTEM32\MSCOREE.DLL; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\CLSID\{{3b72bb68-7363-45a2-9eba-55c8d5f36e36}; ValueType: string; ValueName: Class; ValueData: Cosmos.VS.Package.VMOptionsPropertyPage; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\CLSID\{{3b72bb68-7363-45a2-9eba-55c8d5f36e36}; ValueType: string; ValueName: CodeBase; ValueData: {app}\build\vsip\Cosmos.VS.Package.dll; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\CLSID\{{3b72bb68-7363-45a2-9eba-55c8d5f36e36}; ValueType: string; ValueName: ThreadingModel; ValueData: Both; Flags: uninsdeletevalue uninsdeletekeyifempty

Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\Projects\{{471ec4bb-e47e-4229-a789-d1f5f83b52d4}; ValueType: none; Flags: uninsdeletekey
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\Projects\{{471ec4bb-e47e-4229-a789-d1f5f83b52d4}; ValueType: string; ValueName: ; ValueData: VSProjectFactory; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\Projects\{{471ec4bb-e47e-4229-a789-d1f5f83b52d4}; ValueType: string; ValueName: DisplayName; ValueData: Cosmos; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\Projects\{{471ec4bb-e47e-4229-a789-d1f5f83b52d4}; ValueType: string; ValueName: DisplayProjectFileExtensions; ValueData: "Cosmos Project Files (*.Cosmos);*.Cosmos"; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\Projects\{{471ec4bb-e47e-4229-a789-d1f5f83b52d4}; ValueType: string; ValueName: Package; ValueData: {{4cae44ed-88b9-4b7c-822b-b040f18fcee3}; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\Projects\{{471ec4bb-e47e-4229-a789-d1f5f83b52d4}; ValueType: string; ValueName: DefaultProjectExtension; ValueData: Cosmos; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\Projects\{{471ec4bb-e47e-4229-a789-d1f5f83b52d4}; ValueType: string; ValueName: PossibleProjectExtensions; ValueData: Cosmos; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\Projects\{{471ec4bb-e47e-4229-a789-d1f5f83b52d4}; ValueType: string; ValueName: ProjectTemplatesDir; ValueData: {app}\build\vsip\..\Templates\Projects\CosmosProject; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\Projects\{{471ec4bb-e47e-4229-a789-d1f5f83b52d4}; ValueType: string; ValueName: Language(VsTemplate); ValueData: CosmosProject; Flags: uninsdeletevalue uninsdeletekeyifempty

Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\NewProjectTemplates\TemplateDirs\{{4cae44ed-88b9-4b7c-822b-b040f18fcee3}; ValueType: none; Flags: uninsdeletekey
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\NewProjectTemplates\TemplateDirs\{{4cae44ed-88b9-4b7c-822b-b040f18fcee3}\/1; ValueType: string; ValueName: ; ValueData: Cosmos; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\NewProjectTemplates\TemplateDirs\{{4cae44ed-88b9-4b7c-822b-b040f18fcee3}\/1; ValueType: dword; ValueName: SortPriority; ValueData: $00000064; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\NewProjectTemplates\TemplateDirs\{{4cae44ed-88b9-4b7c-822b-b040f18fcee3}\/1; ValueType: string; ValueName: TemplatesDir; ValueData: {app}\build\vsip\..\Templates\Projects\CosmosProject; Flags: uninsdeletevalue uninsdeletekeyifempty

Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\AD7Metrics\Engine\{{FA1DA3A6-66FF-4c65-B077-E65F7164EF83}; ValueType: none; Flags: uninsdeletekey
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\AD7Metrics\Engine\{{FA1DA3A6-66FF-4c65-B077-E65F7164EF83}; ValueType: string; ValueName: ; ValueData: guidCosmosDebugEngine; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\AD7Metrics\Engine\{{FA1DA3A6-66FF-4c65-B077-E65F7164EF83}; ValueType: string; ValueName: CLSID; ValueData: {{8355452D-6D2F-41B0-89B8-BB2AA2529E94}; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\AD7Metrics\Engine\{{FA1DA3A6-66FF-4c65-B077-E65F7164EF83}; ValueType: string; ValueName: ProgramProvider; ValueData: {{B4DE9307-C062-45F1-B1AF-9A5FB25402D5}; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\AD7Metrics\Engine\{{FA1DA3A6-66FF-4c65-B077-E65F7164EF83}; ValueType: dword; ValueName: Attach; ValueData: $00000001; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\AD7Metrics\Engine\{{FA1DA3A6-66FF-4c65-B077-E65F7164EF83}; ValueType: dword; ValueName: AddressBP; ValueData: $00000000; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\AD7Metrics\Engine\{{FA1DA3A6-66FF-4c65-B077-E65F7164EF83}; ValueType: dword; ValueName: AutoSelectPriority; ValueData: $00000004; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\AD7Metrics\Engine\{{FA1DA3A6-66FF-4c65-B077-E65F7164EF83}; ValueType: dword; ValueName: CallstackBP; ValueData: $00000001; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\AD7Metrics\Engine\{{FA1DA3A6-66FF-4c65-B077-E65F7164EF83}; ValueType: string; ValueName: Name; ValueData: Cosmos Debug Engine; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\AD7Metrics\Engine\{{FA1DA3A6-66FF-4c65-B077-E65F7164EF83}; ValueType: string; ValueName: PortSupplier; ValueData: {{708C1ECA-FF48-11D2-904F-00C04FA302A1}; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\AD7Metrics\Engine\{{FA1DA3A6-66FF-4c65-B077-E65F7164EF83}; ValueType: string; ValueName: guidCOMPlusNativeEng; ValueData: {{92EF0900-2251-11D2-B72E-0000F87572EF}; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\AD7Metrics\Engine\{{FA1DA3A6-66FF-4c65-B077-E65F7164EF83}; ValueType: string; ValueName: guidCOMPlusOnlyEng; ValueData: {{449EC4CC-30D2-4032-9256-EE18EB41B62B}; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\AD7Metrics\Engine\{{FA1DA3A6-66FF-4c65-B077-E65F7164EF83}; ValueType: string; ValueName: guidNativeOnlyEng; ValueData: {{449EC4CC-30D2-4032-9256-EE18EB41B62B}; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\AD7Metrics\Engine\{{FA1DA3A6-66FF-4c65-B077-E65F7164EF83}; ValueType: string; ValueName: guidScriptEng; ValueData: {{F200A7E7-DEA5-11D0-B854-00A0244A1DE2}; Flags: uninsdeletevalue uninsdeletekeyifempty

Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\CLSID\{{8355452D-6D2F-41B0-89B8-BB2AA2529E94}; ValueType: none; Flags: uninsdeletekey
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\CLSID\{{8355452D-6D2F-41B0-89B8-BB2AA2529E94}; ValueType: string; ValueName: Assembly; ValueData: Cosmos.Debug.VSDebugEngine; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\CLSID\{{8355452D-6D2F-41B0-89B8-BB2AA2529E94}; ValueType: string; ValueName: Class; ValueData: Cosmos.Debug.VSDebugEngine.AD7Engine; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\CLSID\{{8355452D-6D2F-41B0-89B8-BB2AA2529E94}; ValueType: string; ValueName: InprocServer32; ValueData: c:\windows\system32\mscoree.dll; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\CLSID\{{8355452D-6D2F-41B0-89B8-BB2AA2529E94}; ValueType: string; ValueName: CodeBase; ValueData: {app}\Build\VSIP\Cosmos.Debug.VSDebugEngine.dll; Flags: uninsdeletevalue uninsdeletekeyifempty

Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\CLSID\{{B4DE9307-C062-45F1-B1AF-9A5FB25402D5}; ValueType: none; Flags: uninsdeletekey
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\CLSID\{{B4DE9307-C062-45F1-B1AF-9A5FB25402D5}; ValueType: string; ValueName: Assembly; ValueData: Cosmos.Debug.VSDebugEngine; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\CLSID\{{B4DE9307-C062-45F1-B1AF-9A5FB25402D5}; ValueType: string; ValueName: Class; ValueData: Cosmos.Debug.VSDebugEngine.AD7ProgramProvider; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\CLSID\{{B4DE9307-C062-45F1-B1AF-9A5FB25402D5}; ValueType: string; ValueName: InprocServer32; ValueData: c:\windows\system32\mscoree.dll; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; SubKey: Software\Microsoft\VisualStudio\9.0\CLSID\{{B4DE9307-C062-45F1-B1AF-9A5FB25402D5}; ValueType: string; ValueName: CodeBase; ValueData: {app}\Build\VSIP\Cosmos.Debug.VSDebugEngine.dll; Flags: uninsdeletevalue uninsdeletekeyifempty

; AssemblyFolder
Root: HKLM; SubKey: Software\Cosmos; ValueType: none; Flags: uninsdeletekey
Root: HKLM; SubKey: Software\Cosmos; ValueType: string; ValueName: ; ValueData: "{app}"

[Run]
Filename: "{code:VSNET2008_PATH|}\devenv.exe"; Parameters: "/setup"; Flags: waituntilterminated

[UninstallRun]
Filename: "{code:VSNET2008_PATH|}\devenv.exe"; Parameters: "/setup"; Flags: waituntilterminated

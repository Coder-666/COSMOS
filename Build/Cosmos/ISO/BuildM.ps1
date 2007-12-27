function Pause ($Message="Press any key to continue...") {
	Write-Host -NoNewLine $Message
	$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
	Write-Host ""
}


"You must first run Set-ExecutionPolicy remotesigned"
"You may also have to unblock this file using file, properties in explorer"

# call msbuild3_5 d:\dotnet\il2asm\repos\source\IL2CPU.sln

# ----------- Compile with IL2CPU
remove-item output.asm -ea SilentlyContinue
..\..\..\source\il2cpu\bin\Debug\il2cpu "-in:..\..\..\source\Cosmos\Cosmos.Shell.Console\bin\Debug\Cosmos.Shell.Console.exe" "-plug:..\..\..\source\Cosmos\Cosmos.Kernel.Plugs\bin\Debug\Cosmos.Kernel.Plugs.dll" "-out:output.obj" "-platform:nativex86" "-asm:output.asm"
remove-item files\output.obj -ea SilentlyContinue
copy-item output.obj files\output.obj
pause

# ----------- Build ISO
remove-item cosmos.iso -ea SilentlyContinue
attrib files\boot\grub\stage2_eltorito -r
..\..\..\Tools\mkisofs\mkisofs -R -b boot/grub/stage2_eltorito -no-emul-boot -boot-load-size 4 -boot-info-table -o Cosmos.iso files
pause

# ----------- Start QEMU
remove-item serial-debug.txt -ea SilentlyContinue
cd ..\..\..\tools\qemu\
.\qemu -L . -cdrom ..\..\build\Cosmos\ISO\Cosmos.iso -boot d -hda ..\..\build\Cosmos\ISO\C-drive.img -serial "file:..\..\build\Cosmos\ISO\serial-debug.txt" -S -s



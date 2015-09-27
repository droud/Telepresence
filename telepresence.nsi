; Telepresence.nsi
; NSIS installation script for Telepresence

; The name of the installer
Name "Telepresence"

; The file to write
OutFile "TelepresenceInstaller.exe"

; The default installation directory
InstallDir "$WINDIR\system32"

; Request application privileges for Windows Vista
RequestExecutionLevel admin

; Installation
Section "Install"

  ; Set output path to the installation directory.
  SetOutPath "$WINDIR\system32"
  
  ; Put file there
  File "/oname=Telepresence.Screensaver.scr" "Telepresence.Screensaver\bin\Release\Telepresence.Screensaver.exe"
  File "/oname=Telepresence.Screensaver.scr.config" "Telepresence.Screensaver\bin\Release\Telepresence.Screensaver.exe.config"

  File "/oname=iConfClient.NET.dll" "Telepresence.Screensaver\bin\Release\iConfClient.NET.dll"
  File "/oname=iConfClient.NET.xml" "Telepresence.Screensaver\bin\Release\iConfClient.NET.xml"

  File "/oname=iConfServer.NET.dll" "Telepresence.Screensaver\bin\Release\iConfServer.NET.dll"
  File "/oname=iConfServer.NET.xml" "Telepresence.Screensaver\bin\Release\iConfServer.NET.xml"
  
  ; Uninstall stuff
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\TelepresenceScreensaver" "DisplayName" "Telepresence Screensaver"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\TelepresenceScreensaver" "UninstallString" "$WINDIR\system32\TelepresenceUninstall.exe"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\TelepresenceScreensaver" "Publisher" "gdroud@gmail.com"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\TelepresenceScreensaver" "DisplayVersion" "1.0.0"
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\PicturesScreensaver" "NoModify" 1
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\PicturesScreensaver" "NoRepair" 1
  WriteUninstaller "TelepresenceUninstall.exe"

  ; Set the active screensaver - BREAKS CONTROL PANEL
  ;WriteRegStr HKCU "Control Panel\desktop" "SCRNSAVE.EXE" "Telepresence.scr"
  ;WriteRegStr HKCU "Control Panel\desktop" "ScreenSaveActive" "1"
  ;System::Call 'user32.dll::SystemParametersInfo(17, 1, 0, 2)'
  
  ; Start configuration - HANDLED BY CONTROL PANEL
  ;Exec "$WINDIR\system32\Pictures.scr /c"
  
  ; Open control panel so they can set screen saver
  Exec "RunDll32.exe shell32.dll,Control_RunDLL desk.cpl,,1"
SectionEnd

; Uninstallation
Section "Uninstall"
  
  ; Remove registry keys
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Telepresence"
  DeleteRegKey HKCU "Software\droud\Telepresence"

  ; Remove files and uninstaller
  Delete "$WINDIR\system32\Telepresence.Screensaver.scr"
  Delete "$WINDIR\system32\Telepresence.Screensaver.scr.config"
  Delete "$WINDIR\system32\iConfClient.NET.dll"
  Delete "$WINDIR\system32\iConfClient.NET.xml"
  Delete "$WINDIR\system32\iConfServer.NET.dll"
  Delete "$WINDIR\system32\iConfServer.NET.xml"
  Delete "$WINDIR\system32\Telepresence.ScreensaverUninstall.exe"

SectionEnd
# A Simple Telepresence Screensaver

This screensaver displays the current conversation between the
included video conferencing tool.  It's really simple, and requires
you to know the IP of the remote computer to establish a connection.

This is based on the excellent but closed source AVSPEED iConf.NET
library.  You'll need to download it and reference the DLLs to
compile or install.

So far as I'm aware, nothing else is available for Windows that
lets you video conference with people sitting at your locked screen.

## Features

* Telepresence via real time video conferencing
* Easy installation and uninstallation

## Usage

### Installer
1. Download the [installer](https://raw.github.com/droud/Telepresence/master/TelepresenceInstaller.exe) and run it
1. Select the "Telepresence" screensaver in the dialog, then click on "OK"

### Manual Install
1. Build the project in release mode (Visual Studio 2015+)
1. Rename the output "Telepresence.Screensaver.exe" file to "Telepresence.Screensaver.scr"
1. Right click on the "Telepresence.Screensaver.scr" file and click "Install"

### Build Installer
1. Build the project in release mode (Visual Studio 2015+)
1. Build the "telepresence.nsi" file (NSIS 2.46+)

### Debug
    Be sure to provide /c or /s options in the project settings under "Debug/Command line arguments" in Visual Studio!

## Future
* Wire up more of the features iConf.NET offers, such as desktop sharing
* Workaround for Remote Desktop disabling screensavers during sessions
* Faster screen blanking during startup
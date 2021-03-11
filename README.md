# ServiceLauncher
Provides an interface between a service and the user.


# Usage (planned)
Installing:
1. LauncherService install {name} {program_to_start} {startup_commands} {shutdown_commands}
2. The launched program and command line arguments can be modified in %ProgramData%\name\launch.ini
3. The startup commands can be modified in %ProgramData%\name\startup.ini
4. The shutdown commands can be modified in %ProgramData%\name\shutdown.ini

Uninstalling:
1. LauncherService uninstall {name}

Interacting with a running service:
1. LauncherService interact {name}

Command line help:
1. LauncherService help {install | uninstall | interact}

Any other arguments will launch the GUI.

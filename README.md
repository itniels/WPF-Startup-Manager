# WPF Startup Manager
A simple class library to manage startup with windows in WPF applications.

## Features
- [x] Check if set as startup
- [x] Add to windows startup (Current User + All Users)
- [x] Remove from windows startup (Current User + All Users)
- [x] Check if user has administrator privileges.

## Tested on
- [ ] Windows 7
- [ ] Windows 8
- [x] Windows 8.1
- [x] Windows 10 (Working)
- [x] Windows Server 2012 R2 (Working)

## Installation
Download the .dll and add to references in your project.

or

Download the NuGet package here: https://www.nuget.org/packages/NovaKittySoftware.wpf.StartupManager/

## Usage
Wpf Startup Manager has a few methods that can be called, and these will be explained here in detail.
There are 3 groups within the namespace: 'NovaKittySoftware.wpf.StartupManager':
- Admin
- AllUsers
- CurrentUser

These are pretty self explanatory (i hope) ;)
and under each are the available public methods that you will need.

All methods return a boolean that is checked after the action is completed and you can test the output.

Just remember to be consistent with the application name!
As this is what the library looks for in the registry.

## Examples
Adding a program to widows startup for the current user only:
```C#
public void AddToStartup(){
  NovaKittySoftware.wpf.StartupManager.CurrentUser.AddApplicationToStartup(MyAppName);
}
```
Removing a program to widows startup for all users:
```C#
public void RemoveFromStartup(){
  NovaKittySoftware.wpf.StartupManager.AllUsers.RemoveApplicationFromStartup(MyAppName);
}
```

Check if application is set for startup or not for current user:
```C#
public void CheckStartup(){
  bool isStartup = NovaKittySoftware.wpf.StartupManager.CurrentUser.IsStartup(MyAppName);
}
```

Check if the current user is administrator:
```C#
public void CheckAdmin(){
  bool isAdmin = NovaKittySoftware.wpf.StartupManager.Admin.IsUserAdministrator();
}
```

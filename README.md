# Ponsole
The open-source terminal written in C#

# Download

Ponsle for Windows (64bit) can be downloaded: [here](https://github.com/Ponsle/Ponsole/blob/master/Ponsole_Setup_Win64.exe?raw=true)

# Q&A

Q: How do I get Ponsle?

A: We are currenly working on an installer for Ponsle but you can allways clone this git repository with `git clone` and open the folder where Ponsle is and run `Ponsle.sln` then just Go to Build > Build Solution and make a new folder somewhere and copy `ponsle64.exe`, `PonsleAPI.dll` and `SmartUtils.dll`. Finally, create a folder inside the follder you were currently in and call it `Plugins` then copy `Ponsle_std.dll` to the `Plugins` folder. Ta da! You can now run ponsle64.exe and Ponsle should load! And by the way, all stable builds are pused to the `master` branch on this repository.

Q: What operating systems does Ponsle run on?

A: Ponsle currently only works on 64 Bit versions of Windows. We are hopefully going to reach out to the Linux and MacOS platforms at a later date and maybe we'll produce some 32 Bit binaries.

Q: Why isn't there a 32 Bit version of Ponsle?

A: We do not provide at 32Bit version at the moment as whilst Ponsle is still in development we feel theat Ponsle may need quite a lot of RAM available to process e.g More than `4GB`.

# About
I made this script to automate building the project and compiling the image using qemu.

# Usage
```
$ ./run.sh -i Lucsin.iso -m 1G -h Filesystem.vhdx

```

Arugments:

* -i  : specifies the ISO file. Lucsin.iso has to be used for the project.
* -m  :  Specifies the memory. Lucsin needs >= 10MB to fully function with room to spare.
* -h  : Specifies The V-irtal H-ard D-sk(VHD For short). Also in our case known as the VHDX. You can replace the Filesystem.vhdx with what ever you want, but it needs to have Lucsin's file system.

#!/bin/bash

# Made By Leviathan
helpFunction()
{
   echo ""
   echo "Usage: $0 -i <ISO> -m <memory size> -h <hdd image>"
   echo "\t-i ISO path to be used"
   echo "\t-m Memory size to allocate to the Virtual Machine"
   echo "\t-h Hard disk image location, can be created with qemu-img"
   exit 1 # Exit script after printing help
}

while getopts "i:m:h:" opt
do
   case "$opt" in
      i ) ISO="$OPTARG" ;;
      m ) MEMORY_SIZE="$OPTARG" ;;
      h ) HDD_IMAGE="$OPTARG" ;;
      ? ) helpFunction ;; # Print helpFunction in case parameter is non-existent
   esac
done

# Print helpFunction in case parameters are empty
if [ -z "$ISO" ] || [ -z "$MEMORY_SIZE" ] || [ -z "$HDD_IMAGE" ]
then
   echo "Some or all of the parameters are empty";
   helpFunction
fi

echo "###--- Made By Leviathan(https://github.com/Leviathenn) ---###"

# Build the project
dotnet build

# Emulate the ISO with VHDX as file system
#qemu-img create -f vhdx $HDD_IMAGE -m

qemu-system-x86_64 -boot d -cdrom bin/Debug/net6.0/$ISO -drive file=$HDD_IMAGE,format=vhdx -m $MEMORY_SIZE

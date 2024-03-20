#!/bin/bash

if [ "$#" -ne 2 ]; then
    echo "Использование: $0 <DIRECTORY> <EXTENSION>"
    exit 1
fi

DIRECTORY=$1
EXTENSION=$2

cd $DIRECTORY
rm *$EXTENSION

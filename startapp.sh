#!/bin/sh

answer=$#

interactive() {
    read -p "Start consoleapp or test? ((a)pp/(t)est): " answer
}

if [ $# = '0' ]; then
    interactive
else
    answer=$1
fi

case $answer in
    'app' | 'a') dotnet run -p Buckets.App/ ;;
    'test' | 't') cmd='dotnet test' ; cd Buckets.Test/ && $cmd ;;
    *) echo "unrecognized" ;;
esac

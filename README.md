# 👽 Alien Factory

[![build](https://github.com/si618/alien-factory/actions/workflows/build.yml/badge.svg)](https://github.com/si618/alien-factory/actions/workflows/build.yml)
[![License](https://img.shields.io/badge/license-Apache_2.0-blue.svg)](LICENSE)

Custom LED programming for my latest PC build.

Effects are triggered based upon current state of PC temperature, CPU and memory load, with integration between LEDs on
fans, RAM sticks, strimer and water cooler block.

## 🙇‍♂️ Kudos

- The [amazing OpenRGB](https://openrgb.org) project and community
- Diogo Trindade and contributors for [OpenRGB.NET client](https://github.com/diogotr7/OpenRGB.NET)
- Stipec for an [article](https://dev.to/stipecmv/touch001-solving-tray-icon-and-minimalize-ui-problem-on-arch-linux-with-c-in-avalonia-1f2g)
on implementing an Avalonia tray icon. Also thanks to Aexia for their comment.

## 🎉 Demo

TODO

## 🏗 Build️

```bash
> dotnet --list-sdks
8.0.101 [/usr/share/dotnet/sdk]

> git --version
git version 2.43.0

> git clone https://github.com/si618/alien-factory.git
Cloning into 'alien-factory'...

> cd alien-factory
> dotnet build
```

## 🧪 Test

```bash
> dotnet test
```

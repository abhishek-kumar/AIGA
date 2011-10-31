echo off

echo Microsoft Office XP Primary Interop Assemblies Registration Utility
echo Copyright (c) 2002 Microsoft(R) Corporation. All rights reserved.
echo Note: This utility must be run from the Visual Studio .NET Command Prompt. It will not function properly otherwise.
echo Start adding primary interop assemblies to the global assembly cache.

echo on

gacutil -i Microsoft.Office.Interop.Access.dll
gacutil -i adodb.dll
gacutil -i dao.dll
gacutil -i Microsoft.Office.Interop.Excel.dll
gacutil -i Microsoft.Office.Interop.FrontPage.dll
gacutil -i Microsoft.Office.Interop.FrontPageEditor.dll
gacutil -i Microsoft.Office.Interop.Graph.dll
gacutil -i Microsoft.Office.Interop.Visio.dll
gacutil -i mscomctl.dll
gacutil -i msdatasrc.dll
gacutil -i Microsoft.Office.Interop.SmartTag.dll
gacutil -i office.dll
gacutil -i Microsoft.Office.Interop.Outlook.dll
gacutil -i Microsoft.Office.Interop.OutlookViewCtl.dll
gacutil -i Microsoft.Office.Interop.Owc.dll
gacutil -i Microsoft.Office.Interop.PowerPoint.dll
gacutil -i Microsoft.Office.Interop.Publisher.dll
gacutil -i stdole.dll
gacutil -i Microsoft.Vbe.Interop.dll
gacutil -i Microsoft.Office.Interop.Word.dll

echo off

echo End adding assemblies to the global assembly cache.

echo Start adding registry entries for each primary interop assembly.

echo on

regedit /s Microsoft.Office.Interop.Access.dll.reg
regedit /s adodb.dll.reg
regedit /s dao.dll.reg
regedit /s Microsoft.Office.Interop.Excel.dll.reg
regedit /s Microsoft.Office.Interop.FrontPage.dll.reg
regedit /s Microsoft.Office.Interop.FrontPageEditor.dll.reg
regedit /s Microsoft.Office.Interop.Graph.dll.reg
regedit /s Microsoft.Office.Interop.Visio.dll.reg
regedit /s mscomctl.dll.reg
regedit /s msdatasrc.dll.reg
regedit /s Microsoft.Office.Interop.SmartTag.dll.reg
regedit /s office.dll.reg
regedit /s Microsoft.Office.Interop.Outlook.dll.reg
regedit /s Microsoft.Office.Interop.OutlookViewCtl.dll.reg
regedit /s Microsoft.Office.Interop.Owc.dll.reg
regedit /s Microsoft.Office.Interop.PowerPoint.dll.reg
regedit /s Microsoft.Office.Interop.Publisher.dll.reg
regedit /s stdole.dll.reg
regedit /s Microsoft.Vbe.Interop.dll.reg
regedit /s Microsoft.Office.Interop.Word.dll.reg

echo off

echo End adding registry entries for each primary interop assembly.

echo Operation complete.

echo on
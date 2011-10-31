We took a copy of the following DirectShow and DirectX headers in order to avoid everyone needing to download 
and install the complete SDKs just to build our code.  However, that means these files will end up out of sync 
with newer versions.

The DX90\Include folder is from the December 2005 DirectX SDK.

The BaseClasses, Include and Lib folders are from the Windows Server 2003 R2 Platform SDK March 2006 edition
(where DirectShow was the only component installed).

Because DirectX ships an old version of strsafe.h which introduces build warnings, I have adjusted the 
projects to include the headers installed with VS 2005 before the DX headers.

Also note, this is for x86 only.  You will need to install the proper SDKs and tools if you want to build 64 
bit versions.
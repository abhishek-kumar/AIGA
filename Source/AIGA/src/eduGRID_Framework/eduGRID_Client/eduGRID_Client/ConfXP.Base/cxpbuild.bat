:: Build Everything - pass debug or release

:: Core APIs

msbuild .\Solutions\ConferenceAPI.sln /t:Build /p:Configuration=%1

:: Services - Archiver, Venue Service and Reflector

msbuild .\Solutions\ServiceCommon.sln /t:Build /p:Configuration=%1
msbuild .\Solutions\Archive.sln /t:Build /p:Configuration=%1
msbuild .\Solutions\VenueService.sln /t:Build /p:Configuration=%1
msbuild .\Solutions\Reflector.sln /t:Build /p:Configuration=%1

:: Capabilities and Client (dependency on Archiver)

msbuild .\Solutions\AudioVideo.sln /t:Build /p:Configuration=%1
msbuild .\Solutions\Capabilities.sln /t:Build /p:Configuration=%1
msbuild .\Solutions\BarUI.sln /t:Build /p:Configuration=%1

:: Samples

msbuild .\Solutions\AudioVideo_Samples.sln /t:Build /p:Configuration=%1
msbuild .\Solutions\ConferenceAPI_Samples.sln /t:Build /p:Configuration=%1
msbuild .\Solutions\RtpAPI_Samples.sln /t:Build /p:Configuration=%1

:: Setup solutions (msbuild can't build them)

devenv .\Setup\_Solutions\Archive_Setup.sln /Build %1
devenv .\Setup\_Solutions\CXP_Setup.sln /Build %1
devenv .\Setup\_Solutions\Reflector_Setup.sln /Build %1
devenv .\Setup\_Solutions\VenueService_Setup.sln /Build %1
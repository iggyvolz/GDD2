UNITY3D=Unity
build:
	Unity -projectPath . -quit -batchmode -executeMethod BuildCommand.PerformBuild -logFile out.log -buildFor $(PLATFORM)

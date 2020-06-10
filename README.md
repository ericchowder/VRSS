# VRSS
Electrical and Computer Engineering (ECE) Capstone project for ELEC498 at Queen's University, Virtual Reality Surgery Simulator.

## Set up
The entire system set up is no longer possible due to the requirement for the custom gloves created by Adel and Monica which used Arduino megas and a couple gyroscopes/accelerometers. Please check reports for full details.

The Unity executable file, however, is still deployable. The "myVRtest_64_editted_0.2_handMovement.exe" was most up-to-date file found available. The file requires the "UnityPlayer.dll" and it's respective \_Data file (myVRtest_64_editted_0.2_handMovement_Data) to run. Once those files are downloaded the Unity Executable file should run. 

In order for the VRSS environment to be viewed in a virtual reality environment, a Google Cardboard-style VR headset is required, along with an Android smartphone with gyroscope-enabled powerful enough to run VR. The Trinus APK must be installed, and act as a slave while the Trinus host application must be installed on Windows. Through the in-app set up, the wifi-enabled computer/laptop will connect to the phone via LAN, and a proper Master/Slave connection will be formed. The Android smartphone must be propped in the Google Cardboard-style VR headset, and the user will be able to look around via the gyroscope within the Android smartphone.

Please refer to the final report for more details on hardware and software specificity.

## Directories
Only important files were pushed to Github. This includes source files and executables along with their dependencies required to run the application.

"VR App Test 1" was a prototype environment used to test out the VR functionality with the hardware infrastructure in place. This included the custom VR gloves along with Android display of the VR environment. The main VR environment was then developed within "VR App Test" (with no '1', yes horrible naming please forgive me) where the main VRSS VR environment was developed.

## Sample Images
![VRSS_Sample_img](https://github.com/ericchowder/VRSS/blob/master/VRSS_Unity_img.PNG?raw=true)

## Disclaimer
This project is was conceptualized in 2016 and was completed in 2018. Due to the reliance on custom gloves (that were evenutally bought out by Adel and Monica, the electrical engineers in this project), the project has not been maintained. "VR App Test 1" is also missing shaders due to file length being too long to pushed via Git.

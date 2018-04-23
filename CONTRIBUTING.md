
# How to contribute

This project is development as result of a university program for Neuroscience and Behaviour Laboratory in Biology Department of Universidade de Brasília (UnB),
students are responsible for this code, but is built so that anyone willing to contribute can modify and help with development using github. In this file, that are some instructions and suggestions upon how to make your contribution, please read it before sending your changes.
 

# Prerequisites

* Microsoft Visual Studio 2015+
* [ResXManager](https://marketplace.visualstudio.com/items?itemName=TomEnglert.ResXManager) extension for VS



# Getting Started

To have access to our project you just have to clone this repository and open the .sln file (Microsoft Visual Studio Solution).

# Globalization

This program is currently available on:
* English
* Portuguese

Releases are made with separate versions of each language.
There are texts needing translation to spanish [here](https://drive.google.com/open?id=174o9u04dX0g0KubeW1F5CiOCXC9EoPJ1hs0i8ae4fMU) so that it can also be available in spanish.

Localization is made by the use of resx files, managed on [ResXManager](https://marketplace.visualstudio.com/items?itemName=TomEnglert.ResXManager) a VS extension. 
Winform forms and usercontrols can be localizated only when their property "Localizable" is set true. Which of these files have a .resx for available languages that is used for static elements.

For dynamic elements, such as error messages displayed during run time, that are global resources located in:

![Localization Resources](https://github.com/lab-neuro-comp/Test-Platform/blob/master/images/localization_resources.png?raw=true)

To use resources in global files 


```
// properties used to localize strings during runtime
private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
private CultureInfo currentCulture = CultureInfo.CurrentUICulture;

// getting string "reactionTest" from resources in current culture
LocRM.GetString("reactionTest", currentCulture)
```


# Data structure

There is no database in this application, instead files are used. Below there is an image of the directory tree created for the program.

![Data structure](https://github.com/lab-neuro-comp/Test-Platform/blob/master/images/data_structure.png?raw=true)


# Testing

Unit tests are kept in their own project inside solution. Until now, that are only tests for model classes.

![Tests project](https://github.com/lab-neuro-comp/Test-Platform/blob/master/images/test_project.png?raw=true)

You can run tests using visual studio default configurations.

![Running tests](https://github.com/lab-neuro-comp/Test-Platform/blob/master/images/run_tests.png?raw=true)

# Submitting changes

Please send a [GitHub Pull Request to TestPlatform](https://github.com/lab-neuro-comp/Test-Platform/pull/new/master) stating what you've done. 
The Pull Request will only be accepted if the contribution works in all cultures (en-US and pt-BR).


# Deployment



For this project deployment, follow the steps below (You need  WinRAR to be installed in your computer)



1. Change localization to specific culture that will be released. Don't forget to also change version in AssemblyInfo.cs (Inside Properties)


![enter image description here](https://github.com/lab-neuro-comp/Test-Platform/blob/master/images/main_culture.png?raw=true)



2. Go to project properties and click on the left menu on publish, changing application files accordingly to culture being published. Then, click on the Publish Wizard



![enter image description here](https://github.com/lab-neuro-comp/Test-Platform/blob/master/images/publish_projects.png?raw=true)



3. Right click on the folder created after published,  and click to add to file (using WinRAR).


4. Use WinRAR advanced SFX options to create an executable of the compressed files


![enter image description here](https://github.com/lab-neuro-comp/Test-Platform/blob/master/images/sfx_shortcut.png?raw=true)



![enter image description here](https://github.com/lab-neuro-comp/Test-Platform/blob/master/images/sfx_text.png?raw=true)

# AR-Target-Indicator-Tool

The **_AR-Target-Indicator-Tool_** for **_Unity3D_** allows you to display a marker on your UI to indicate where a predefined target is located.

## Contents :

- **Introduction** of the tool.
- How to **install the tool** in your project.
- How to **configure the tool** for your project.
- **Test the tool** in the demo project.

## Présentation de l'outil :

This tool will allow you to track a GameObject in your Unity3D scene. The tool will display an image on the UI that will move around the edges of the screen to indicate the position of the target object relative to the current camera position.

This tool requires a version of Unity greater than or equal to [`Unity 2021.X`](https://unity.com/releases/editor/archive)

## How to install the tool in your project :

Download the tool via this **UnityPackage**.

Once downloaded, open Unity and drag it into your `project` window. Once the import window is open, select the `TargetFinderIndicator.cs` script. Make sure its Editor script (`...CustomEditor`) is also selected and click on `import`.

You can find the scripts in :

```
../Assets/Scripts/AR-Target-Indicator-Tool
```

Drag and drop the script on an object present in your scene so that it can be active. It is recommended to add it on the main camera because if the `Camera` field is empty, the script will take the object on which it is present. But you can place it on any object in your scene if you make sure the `Camera` field is filled in.

## How to **configure the tool** for your project :

Once the component is added on an object you have 2 categories:

- **GameObjects**

  In this category you have 3 fields:

  - `Target Indicator UI` > will allow you to fill in an image that will be displayed on your canvas and this same image will move on it to indicate the position of your target.
  - `Target Object` > this field is used to define a GameObject which will be defined as a target by the tool.
  - `Camera` > in this field you have to fill in the camera that will be used as a reference point to calculate the direction between you and the target object.

- **Options**

  - `Always Show Cursor` > By default the target indicator disappears when your target is in the field of view of the camera the tool is using, but by turning this option on you can choose to have the indicator always be visible and pointing at your target even if the object is already in your field of view.

## Test the tool in the demo project :

You can clone the git repo with the following address :

```
git@github.com:LeoSery/AR-Target-Indicator-Tool--Unity3DTool.git
```

or

```
https://github.com/LeoSery/AR-Target-Indicator-Tool--Unity3DTool.git
```

Once the project is open, open the `Main` scene and press `Play` to test the tool in the example scene. You can see how the tool is configured via the `Hierarchy`. The `TargetFinderIndicator` script can be found on the `TargetManager` object in the `---Managers---` category.

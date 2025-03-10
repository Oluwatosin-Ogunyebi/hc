# Hierarchy Colorizer

Hierarchy Colorizer is a Unity Editor package that helps you easily see and organize your GameObjects in the Hierarchy window. With simple color coding based on GameObject tags, you can quickly identify players, enemies, and other objects in your scene.

## Features

- **Automatic Coloring:**  
  GameObjects are highlighted with different colors based on their tags.
- **Easy Customization:**  
  Change which tag gets which color through a simple settings window.
- **Real-Time Updates:**  
  See the changes immediately in your Hierarchy as you adjust the settings.

## Installation via Unity Package Manager

You can install Hierarchy Colorizer in two ways: using a Git URL or as a local package.

### Option 1: Install via Git URL

1. **Add the Package to Your Project:**
   - Open your Unity project.
   - Go to **Window → Package Manager**.
   - Click the **+** button in the top left and select **Add package from Git URL...**.
   - Enter the following URL:
     ```
     https://github.com/Oluwatosin-Ogunyebi/hierarchycolorizer.git?path=/com.kiingot.hc
     ```
   - Click **Add**. The package will be downloaded and installed.

### Option 2: Install as a Local Package

1. **Download the Package:**
   - Download or clone the package folder (named something like `com.kiingot.hc`) to your computer.

2. **Add the Package to Your Unity Project:**
   - Copy the entire package folder.
   - Paste it into your Unity project's `Packages` folder.
   - Unity will automatically detect and install the package.

## How to Use

1. **Open the Settings Window:**
   - In the Unity Editor, go to **Tools → Hierarchy Color Settings**.
   
2. **Configure Your Colors:**
   - In the settings window, you can see a list of tag-color pairs.
   - To change a color, click on the color field next to a tag and pick a new color.
   - To add a new mapping, click **Add New Mapping**.
   - To remove a mapping, click **Remove** next to the unwanted entry.
   - Click **Save Settings** to apply your changes.

3. **View in the Hierarchy:**
   - Open or refresh your Hierarchy window.  
   - Any GameObject with a tag that matches one of your mappings will be highlighted with the chosen color.

## Need Help?

If you have any questions or run into any issues, please contact [Oluwatosin Ogunyebi](mailto:oluwatosinogunyebi@gmail.com) or visit [oluwatosinogunyebi.com](https://oluwatosinogunyebi.com).

## License

This project is licensed under the MIT License.

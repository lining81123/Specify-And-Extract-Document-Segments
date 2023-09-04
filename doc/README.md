# 安装指南 & 使用手册
前提条件：

确保安装了合适版本的 .NET Framework。可以从 [Microsoft](https://dotnet.microsoft.com/zh-cn/download/dotnet-framework) 官方网站上下载并安装所需的版本。

本项目使用.NET Framework 4.7.2


## 使用 Visual Studio 打开

1. 安装 Visual Studio，本项目开发使用 Visual Studio 2022。
   
2. 打开 Visual Studio，选择“打开项目”：在菜单栏中选择 "文件（File）" -> "打开（Open）" -> "项目/解决方案（Project/Solution）"。

3. 选择.NET Framework 项目的项目文件。
   
4. 当项目加载完成后，运行项目。


## 使用 cmd 打开
1. 打开 cmd 命令提示符（Windows 系统）。
   
2. 使用 cd 命令进入 .NET 程序的根目录，该目录包含生成的可执行文件。
   
3. 该程序基于 .NET Framework 开发的，可以直接运行可执行文件，例如：YourProgramName.exe。

<p align="center">
  <img width="500" height="200" src="/img/安装.png">
</p>

## 界面

<p align="center">
  <img width="500" height="350" src="/img/主界面.png">
</p>

## 使用手册
1. 在 Location 后面的栏里输入要查询的位置。

2. 点击"Select File"选择本地需要查找内容的文件（如果是在 Location 中已经设置文件路径，则无需选择文件）。

3. 本项目有两种位置信息的表达方式：
   
   1）[正则表达式](/example/regular-expression/README.md)：点击"Regular Expression"，当位置信息经过正则表达式的验证，正确则弹出所要查找的内容。
   
   2）[XML](/example/xml/README.md)：点击"XML",当位置信息经过 .xsd文件 的验证，正确则弹出所要查找的内容。


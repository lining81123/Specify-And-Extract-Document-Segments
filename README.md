# Specify and Extract Document Segments
This project is used to obtain Word, Excel, PowerPoint, Ofd location content, using regular expression and XML to verify the correctness of the location.

## Environment
Integrated development environment: Visual Studio 2022

Language: C#

Open Software Toolkit: .NET Framework 4.7.2

## Main interface
<p align="center">
  <img width="640" height="400" src="/doc/Img/Main interface.png">
</p>

## Tool Functions
1. Extracts the text content of a Word file at the position of the specified paragraph character.
   
2. Extract the text content of the specified table position in the Word file.

3. Extract the text content of the specified cell in the Excel file.

4. Extract the text content of the specified slide in the PowerPoint file.

5. Extracts the text content of the specified object in the Ofd file.

## Main libraries used
ICSharpCode.SharpZipLib 1.4.2.13

Microsoft.Office.Interop.Word 12.0.0

Microsoft.Office.Interop.Excel 12.0.0

Microsoft.Office.Interop.PowerPoint 12.0.0

Office 12.0.0

## Licenses
Apache 2.0 licenses

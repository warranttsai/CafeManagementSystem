# CafeManagementSystem
This project was used to help myself get more familiar with C# and Visual Studio. Following the tutorial on YouTube, the project is going to deliver a simple café management system.

# Original Tutorial Video
Please view this link for the tutorial.
https://www.youtube.com/watch?v=HR7Pd73BxbI&list=PLBpH5WxSM4d3tXXlS1hQLztvfVPqgwxB2&ab_channel=MyCodeSpace

# How To Execute the Application
Please double click on the CafeManagementSystem.exe, which should be collected under /CafeManagementSystem/bin/Debug.

# General Usage
You can sign in with an existing account (E.g., account: user1, password: 123). In the user panel, you can create another new account. Also, as a user or a guest, you can place an order with different numbers of items. The amount of order and date will be saved in the database. The difference between the user and the guest was to be able to manage the user and items in the database. Only the users are permitted to modify the item and user data.

# What Difficulties Had I found? How I Solved It?
##	Being unfamiliar with the syntax of C#, I was a bit struggling with the interface and how to print out the values in my application. After a short time of research, I realized that in the Visual Studio, you can use “System.Console.WriteLine()” to log the variables in the “Output” panel.
##	There seems to be no global style in the whole solution. I couldn’t find a place to place the general styles for my forms. For example, the main container width and height. I had to manually set the size for each container.
##	It seems like there are no reused components in C#.
##	Without text, the label item is unable to be reached.
##	You couldn’t delete the function from .cs directly. You must delete the items with .cs functions synchronously.
##	I couldn’t find the placeholder for label items. In the project, I put in the placeholder in the Text column and replace it when the form loaded.

# Other Notes
##	The entry point of the “Web Application Form” is “Program.cs”. In the static method Main().
##	Each application form has design and script pages.
##	In the design page, you can select the item and adjust the properties on the bottom-right corner in the “Property”.
##	In the “Property”, under “Design” section, the “(Name)” is the variable name in the script page. You must make it unique and meaningful for coding purposes.


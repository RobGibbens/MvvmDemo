

  1. Start Emulators
  2. Create MvvmDemo Directory
  3. git init
  4. add .gitignore
  5. commit
  6. File-New-Project
    a. Other Project Types-Visual Studio Solutions-Blank Solution
    b. MvvmDemo
    c. C:\dev
  7. Add-New Project
    a. Portable Class Library
    b. MvvmDemo.Core
    c. C:\dev\MvvmDemo
    d. .NET Framework 4.5, Windows Phone 8, Windows Store apps (Windows 8)
  8. Delete Class1.cs
  9. Nuget MvvmCross
  10. Show what references were added
  11. Show ToDo-MvvmCross
  12. Show ViewModels folder
    a. Note: Naming is important. Convention based
  13. Show App.cs
  14. Show FirstViewModel
    a. Note : MvxViewModel
    b. Note : RaisePropertyChanged
  15. Change FirstViewModel to UserViewModel
  16. Change Hello to FirstName
  17. Add LastName
  18. Add FullName
  19. WINDOWS PHONE
  20. Add-New Project
    a. Windows Phone-Windows Phone App
    b. MvvmDemo.WinPhone
    c. C:\dev\MvvmDemo
    d. Windows Phone 8.0
  21. Add reference to Core
  22. Nuget MvvmCross
  23. Show ToDo-MvvmCross
  24. Show Setup.cs
  25. Copy code to App.xaml.cs from ToDo
  26. Show Views folder
  27. Delete FirstView.xaml
  28. Add-New Item-Windows Phone-Windows Phone Portrait Page
    a. UserView.xaml
    b. Note : Name is important
  29. Change xaml and code behind to MvxPhonePage
  30. Add StackPanel, TextBox, TextBox, TextBlock
  31. Set WinPhone as Startup Project
  32. Run
  33. WINDOWS STORE
  34. Add-New Project-Windows Store-Blank App
    a. MvvmDemo.WinStore
    b. C:\dev\MvvmDemo
  35. Add reference to Core
  36. Nuget MvvmCross
  37. Show ToDo-MvvmCross
  38. Show Setup.cs
  39. Copy code from ToDo to App.xaml.cs
  40. Show Views folder
  41. Delete FirstView.xaml
  42. To Views folder - Add-New Item-Windows Store-Basic Page
    a. UserView.xaml
    b. Note : Name is important
    c. Click Yes
  43. Change LayoutAwarePage to :MvxStorePage
  44. Remove LayoutAwarePage OnNavigatedTo and OnNavigatedFrom
  45. Add xaml to UserView
  46. Set Store as startup project
  47. Run
  48. IPHONE
  49. Add-New Project-iOS-Xamarin.iOS Library Project
    a. MvvmDemo.Core.iOS
    b. C:\dev\MvvmDemo
  50. Delete Class1.cs
  51. Add Project Link
    a. MvvmDemo.Core
  52. Delete ToDo-MvvmCross, packages.config
  53. Nuget MvvmCross
  54. Delete Views, AppDelegate.cs.txt, DebugTrace.cs, LinkerPleaseInclude.cs, Setup.cs
  55. Add-New Project-iOS-iPhone-Empty Project
    a. MvvmDemo.iOS
    b. C:\dev\MvvmCross
  56. Add reference to Core.iOS
  57. Nuget MvvmCross
  58. Show ToDo-MvvmCross
  59. Show Setup.cs
  60. Change AppDelegate to MvxApplicationDelegate
  61. Copy code to AppDelegate
  62. Delete FirstView.cs
  63. To Views folder, Add-New Item-Code-Class
    a. UserView.cs
  64. Copy UserView class
    a. Explain BindingSet
  65. Set iOS as startup project
  66. Set iPhoneSimulator
  67. Run
  68. ANDROID
  69. Add-New Project-Android Class Library
    a. MvvmDemo.Core.Droid
    b. C:\dev\MvvmDemo
  70. Delete Class1.cs
  71. Add Project Link
    a. MvvmDemo.Core
  72. Delete ToDo-MvvmCross, packages.config
  73. Nuget MvvmCross
  74. Delete Views, DebugTrace.cs, LinkerPleaseInclude.cs, Setup.cs, SplashScreen.cs
  75. Add-New Project-Android-Android Application
    a. MvvmDemo.Droid
    b. C:\dev\MvvmDemo
  76. Delete Activity1.cs
  77. Add reference to Core.Droid
  78. Nuget MvvmCross
  79. Delete Views\FirstView.cs, Resources\Layout\FirstView.axml, Values\MvxBindingAttributes.xml
  80. Show ToDo-MvvmCross
  81. Show Setup.cs
  82. Add-New Item-Class
    a. Views/UserView.cs
  83. Copy code to UserView.cs
  84. Add-New Item-Xamarin.Android-Android Layout
    a. UserView.axml
  85. Add xml to UserView.axml
  86. Setup Droid as startup project
  87. Change to Any CPU
  88. Run
  89. PART 2 - Conferences App - Core
    a. Note : Show tekConf api
  90. 
    a. Note : Shows json plugin, dependency injection, http rest services
  91. Nuget Microsoft.Net.Http to Core
    a. Note : Might have to have Xamarin.iOS reference from C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\MonoTouch\v4.0\System.Net.Http.dll
    b. Note : Reference Http in Droid
    c. Note : Explain System.Net.Http
  92. Add ConferenceDto
    a. Show Project Linked files
  93. Add ConferencesViewModel.cs
  94. Change App.cs RegisterAppStart to ConferencesViewModel
  95. WINDOWS PHONE
  96. Add-New Item-Windows Phone-Windows Phone Portrait Page
    a. Note : ConferencesView.xaml
  97. Change xaml and code behind to MvxPhonePage
  98. Add Json plugin
  99. Add xaml formatting
  100. ANDROID
  101. Add ConferencesView
    a. Add New Item-Xamarin.Andorid-Android Layout  - Resources/Layout/ConferencesListView.axml
    b. Add Resources/Layout/Item_Conference.axml
    c. Add Views/ConferencesListView.cs
  102. Add json plugin
  103. Add File plugin
  104. Add DownloadCache plugin
  105. WINDOWS STORE
  106. Add-New Item-Windows Store-Basic Page
    a. ConferencesView
  107. Add xaml
  108. Add json plugin
  109. Set as startup
  110. iPHONE
  111. Add json to Core.iOS and MvvmDemo.iOS
  112. Add ConferencesView.cs
  113. NAVIGATION
  114. CORE
  115. Add Command to ConferencesViewModel
  116. WINDOWS PHONE
  117. Add button to ConferencesView.xaml
  118. Add reference to System.Windows to Core.iOS
  119. WINDOWS STORE
  120. Add button to ConferencesView.xaml
  121. iOS
  122. Remove ConferencesList, Add button
  123. ANDROID


### windows右键菜单快捷工具

#### 目前已有的工具
1. 复制文件路径：将选中的文件或文件夹的路径复制到剪切板上

### 开发自己的工具
1. 在ContextMenuRegister项目的App.config文件中添加自己想要添加的命令
```C#
<add key="这是自定义的命令" value="命令执行的exe文件名称（eg：test.exe）" />
```
==注意==：value值只需要文件名称即可，默认是会将ContextMenuRegister.exe文件所在文件夹下的worker文件夹**拼接**value指定的exe名称注册到注册表中
2. 编写自己的代码：
	- 无论是在ContextMenuWorker的基础上添加代码，还是使用自己的新建的项目，注意需要修改项目的编码/调试的输出地址，即修改.csproj文件
	```
	  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
	    <PlatformTarget>AnyCPU</PlatformTarget>
	    <DebugSymbols>true</DebugSymbols>
	    <DebugType>full</DebugType>
	    <Optimize>false</Optimize>
	    <OutputPath>这里修改为指向ContextMenuRegister项目woker文件夹的地址</OutputPath>
	    <DefineConstants>DEBUG;TRACE</DefineConstants>
	    <ErrorReport>prompt</ErrorReport>
	    <WarningLevel>4</WarningLevel>
	  </PropertyGroup>
	  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
	    <PlatformTarget>AnyCPU</PlatformTarget>
	    <DebugType>pdbonly</DebugType>
	    <Optimize>true</Optimize>
	    <OutputPath>这里修改为指向ContextMenuRegister项目woker文件夹的地址</OutputPath>
	    <DefineConstants>TRACE</DefineConstants>
	    <ErrorReport>prompt</ErrorReport>
	    <WarningLevel>4</WarningLevel>
	  </PropertyGroup>
	```
	- 如果value值设置为ContextMenuWorker.exe的话，只需要在ContextMenuWorker项目的基础上添加代码即可，Main函数默认会依次传入选中的文件名称、命令名称（即第一步中key值）两个参数
	- 如果value值设置为自定义的exe文件（eg：test.exe），则需要新建自己的项目，同样的Main函数默认会依次传入选中的文件名称、命令名称（即第一步中key值）两个参数

### TODO
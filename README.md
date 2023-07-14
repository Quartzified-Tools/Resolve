# Resolve
A good looking debugger for Unity.
<hr>

### How do I use it?  
Don't worry. The design is very human.
```cs
using Quartzified.Resolve;

public class IHaveMommyIssues
{
  void Start()
  {
      // Works just as Debug.Log but instead its Resolve.Log
      Resolve.Log("Truth or Dare!");
      Resolve.LogWarning("Truth...");

      Resolve.Log("Do you have Mommy issues?");

      // To Log with the Class Type just mention it as the last variable.
      Resolve.Log("I swear I don't have mommy issues", typeof(IHaveMommyIssues));
  }
  
}
```
<hr>

## Colorful Numbers
![image](https://github.com/Quartzified-Tools/Resolve/assets/34374881/11da4305-4ef1-4c30-bfaf-51ad34f031f1)  

## Adjustable Log Colors
![image](https://github.com/Quartzified-Tools/Resolve/assets/34374881/dda359d2-e4b3-4a0c-8de0-cd5b0952de0e)  

## Tagged Logging  
Let it be known what exactly your message was in the Editor and Player Log files with Tags.
![image](https://github.com/Quartzified-Tools/Resolve/assets/34374881/7630fa73-d2e2-4d37-a88d-4f4b9a719989)  

## Tag the Class sending your Logs
![image](https://github.com/Quartzified-Tools/Resolve/assets/34374881/7f8d94de-1d00-407a-b682-e53075dfed53)

## Custom Timestamps  
With the option to enable millisecond accuracy  
![image](https://github.com/Quartzified-Tools/Resolve/assets/34374881/cae3d664-32a3-4caa-80fd-d986a261fb42)


## FAQ

**How do I disable Unitys Timestamps?**  
Click the tripple dots, and disable "Show Timestamp"
![image](https://github.com/Quartzified-Tools/Resolve/assets/34374881/2d4df88e-a650-4be0-b814-ae60080462ca)


**Supported Unity Versions?**  
Definitely Unity 2022.3.2f1  

| **How to install?** | Comments |
|-------------|-------------|
| Using [Git URL](https://docs.unity3d.com/Manual/upm-ui-giturl.html) | Simple but no version control |
| [Clone](https://docs.github.com/en/repositories/creating-and-managing-repositories/cloning-a-repository#cloning-a-repository-to-github-desktop) and install as [local package](https://docs.unity3d.com/Manual/upm-ui-local.html) | Download & freely modify the package|

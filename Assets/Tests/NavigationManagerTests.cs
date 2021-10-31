using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Scripts.Navigation;

public class NavigationManagerTests {

    [Test]
    public void InitializeNavigation_Success()
    {
        NavigationManager navigationManager = new NavigationManager();
        IScreen mockScreenA = Substitute.For<IScreen>();
        List<IScreen> screens = new List<IScreen>(){mockScreenA};
        
        navigationManager.Initialize(screens);
        
        Assert.NotNull(navigationManager.Screens);
    }
    
    [Test]
    public void InitializeNavigation_InvalidList_Failed()
    {
        NavigationManager navigationManager = new NavigationManager();
        
        Assert.That(() => navigationManager.Initialize(null), 
            Throws.TypeOf<System.Exception>());
    }
    

    [Test]
    public void InitializeNavigation_ValidScreens_Success() {
        bool initializedScreenIsCalled = false;
        NavigationManager navigationManager = new NavigationManager();
        IScreen mockScreenA = Substitute.For<IScreen>();
        mockScreenA.Id.Returns("mockScreenA");
        mockScreenA.When(screen => screen.Initialize())
                   .Do(info => initializedScreenIsCalled = true);
        List<IScreen> screens = new List<IScreen>(){mockScreenA};
        
        navigationManager.Initialize(screens);
        
        Assert.NotNull(navigationManager.Screens);
        Assert.AreEqual(true, initializedScreenIsCalled);
    }
    
    
    [Test]
    public void InitializeNavigation_ScreenWithSameId_Failed()
    {
        NavigationManager navigationManager = new NavigationManager();
        IScreen mockScreenA = Substitute.For<IScreen>();
        mockScreenA.Id.Returns("mockScreenA");
        IScreen mockScreenB = Substitute.For<IScreen>();
        mockScreenB.Id.Returns("mockScreenA");
        List<IScreen> screens = new List<IScreen>(){mockScreenA,mockScreenB};
        
        Assert.That(() => navigationManager.Initialize(screens), 
            Throws.TypeOf<System.Exception>());
    }
}






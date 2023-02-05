namespace ToDo_2._0.UnitTests;

[TestClass]
public class PasswordManagerTests
{
    [TestMethod]
    public void PasswordCheck_PassWordisValid_ReturnsTrue()
    {
        //Arrange

        PasswordManager PM = new PasswordManager("Testing1", true);

        //Act
        //Testing with correct password
        bool result = PM.PasswordCheck("Testing1");
        //Assert

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void PasswordCheck_PasswordIsNotValid_ReturnsFalse()
    {
        PasswordManager PM = new PasswordManager("Testing1", true);

        //Testing with incorrect password
        bool result = PM.PasswordCheck("Testing2");

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void Display_PasswordIsHidden_ReturnsHashed()
    {
        //Testing hidden password returns a "*" for each character in password
        string password = "Testing1";

        int length = password.Length;

        string hiddenPassword;

        string[] hide = new string[length];

        for (int i = 0; i < length; i++)
        {
            hide[i] = "*";
        }

        hiddenPassword = string.Join("", hide);

        PasswordManager PM = new PasswordManager(password, true);

        string result = PM.Display();

        Assert.AreEqual(hiddenPassword, result);
    }

    [TestMethod]
    public void Display_PasswordIsNotHidden_ReturnsNotHashed()
    {
        //Testing unhidden password returns string equal to password
        string password = "Testing1";

        PasswordManager PM = new PasswordManager(password, false);

        string result = PM.Display();

        Assert.AreEqual(password, result);
    }

    [TestMethod]
    public void Reset_PasswordCanBeReset_ReturnEmpty()
    {
        //Testing reset password clears password
        PasswordManager PM = new PasswordManager("Testing1", true);

        PM.Reset();

        string result = PM.Display();

        Assert.AreEqual("", result);
    }

    [TestMethod]
    public void ChangePassword_PasswordCanBeChanged_ReturnsNewPassword()
    {
        //Testing password can be changed

        string password1 = "Testing1";
        string password2 = "Testing2";

        PasswordManager PM = new PasswordManager(password1, true);

        //Hidden set to false to verify change for testing purposes

        PM.ChangePassword(password2, false);

        string result = PM.Display();

        Assert.AreEqual(password2, result);
        
    }
}

[TestClass]
public class ToDoTests
{
    [TestMethod]
    public void Add_ToDoItemCanBeAdded_ReturnsEqualString()
    {
        //Testing an added item returns at the appropriate index
        TodoList tdl = new TodoList();

        string item = "Testing1";

        tdl.Add(item);

        string result = tdl.Todos[0];

        Assert.AreEqual(item, result);
    }

    [TestMethod]
    public void Add_ToDoItemsCannotBeAddedOutsideRange_ReturnsFalse()
    {

        TodoList tdl = new TodoList();

        string item1 = "Testing1";
        string item2 = "Testing2";
        string item3 = "Testing3";
        string item4 = "Testing4";
        string item5 = "Testing5";
        string item6 = "Testing6";

        tdl.Add(item1);
        tdl.Add(item2);
        tdl.Add(item3);
        tdl.Add(item4);
        tdl.Add(item5);

        bool result = tdl.Add(item6);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void Display_ToDoItemsCanBeDisplayed_ReturnsEqualString()
    {
        TodoList tdl = new TodoList();

        string item1 = "Testing1";
        string item2 = "Testing2";
        string item3 = "Testing3";
        string item4 = "Testing4";
        string item5 = "Testing5";

        tdl.Add(item1);
        tdl.Add(item2);
        tdl.Add(item3);
        tdl.Add(item4);
        tdl.Add(item5);

        string expected = $"1. {item1} 2. {item2} 3. {item3} 4. {item4} 5. {item5}";

        string result = tdl.Display();

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Remove_ToDoItemCanBeRemoved_ReturnsEqualString()
    {
        TodoList tdl = new TodoList();

        string item1 = "Testing1";
        string item2 = "Testing2";
        string item3 = "Testing3";
        string item4 = "Testing4";
        string item5 = "Testing5";

        tdl.Add(item1);
        tdl.Add(item2);
        tdl.Add(item3);
        tdl.Add(item4);
        tdl.Add(item5);

        //Input is one higher than tru index for ease of operation for user
        tdl.Remove(5);

        string expected = $"1. {item1} 2. {item2} 3. {item3} 4. {item4} 5. ";

        string result = tdl.Display();

        Assert.AreEqual(expected, result);
    }
}

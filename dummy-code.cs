public void Should_Match_All_Properties_of_Same_Type()
        {
            //Create an instance of our test class
            var testInstance = new ContainerClass();

            var nameConst = "AaronConst";

            var fake = new Fake<ContainerClass>();

            //Run some tests before we add the custom selector
            var standardFakeInstance = fake.Generate();

            Assert.AreNotEqual(nameConst, standardFakeInstance.Name);

            //Add the custom selector for the Member field
            var selector = fake.SetType(() => nameConst);

            //Assert.IsTrue(selector.CanBind(typeof(string)));

            //Generate a new fake with the custom selector implemented
            var customFakeInstance = fake.Generate();

            Assert.AreEqual(nameConst, customFakeInstance.Name);
            Assert.AreEqual(nameConst, customFakeInstance.OtherName);
            Assert.AreEqual(nameConst, customFakeInstance.Member.Name);
        }

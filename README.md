# SimpleDatabaseApp

Veckans uppgift har varit utmanande. Mycket på grund av att det var svår att förstå och implementer de simpla exemplen till det vi skulle göra i uppgiften. Det var också många mindre men ack så viktiga moment som var nya och inte helt lätta att greppa. Bland dem är konstruktorinjektion en av dem. Det var någorlunda lätt att hitta hur det gjordes men inte vilka fördelar det medförde och varför man ens skulle ha med den. Något som blev mycket tydligare under livekodningen. Något annat som också blev tydligare under livekodningen men var svårt att greppa var hur man kan använda interface när man skapa Mocks tester. Jag försökte många gånger att skapa tester som inte gick att köra pga den lilla detaljen att det inte fanns någon inplementering av funktionen i ett interface som Moq kunde relatera till när jag gjorde de första öveningarna.
Det jag fortfarande kan tycka är krånbgligt och där det lätt blir fel är när jag ska använda metoder från en klass i en annan klass och hur det då blir med private, abstract, virtual osv. VS code som jag fortsatt använder säger till en att det måste vara si eller så ofta och då ändrar jag. Men jag är inte helt klar med anledningen eller konceptet bakom. 
Att sedan skapa ett lite mer komplicerat test från grunden utan att ta hjälp av googling är också något som jag fortfarnde tycker är svårt. 

Sedan har jag tyckt att det inte var så tydligt när man gick igenom uppgiften vad exakt som skulle avra resultatet eftersom det i början står: 
"Du har fått i uppdrag att skapa en enkel applikation som hanterar användarkonton. Applikationen ska kunna lägga till, ta bort och hämta användare från en databas."

Fick mig direkt att börja fundera på hur man skulle kunna använda applikationen och all den kod som ska skrivas för att ta bort lägga till och all felhantering. Så nu får du en app som man kan använda. 

något som jag också hela tiden försökte få mina tester att göra var detta: 

[Test]
public void RemoveUser_RemovesUserFromDatabase()
{
    // Arrange
    var userIdToRemove = 1;

    var mockDatabase = new Mock<IDatabase>();
    var userToRemove = new User(userIdToRemove, "John");

    mockDatabase.Setup(service => service.GetUser(userIdToRemove)).Returns(userToRemove);

    var userManager = new UserManager(mockDatabase.Object);

    // Act
    userManager.RemoveUser(userIdToRemove);

    // Assert
    mockDatabase.Verify(service => service.RemoveUser(userIdToRemove), Times.Once);

    // Kontrollera att användaren verkligen är borttagen.
    var actualUser = mockDatabase.Object.GetUser(userIdToRemove);
    Assert.IsNull(actualUser, $"Expected user to be null, but got: {actualUser}");
}


Detta testet lyckades jag aldrig få grönt eftersom userIdToRemove aldrig blev Null. Där satt jag kanske en dag och provade ändrå om hela min RemoveUser metod och allt möjligt som kunde få den att påverka men lyckades inte hitta vad det var som gör att den inte blir Null. 
Dock så förstår jag att den inte behövs i det testet vi gör i denna uppgiften, men ville ju gärna få till det och då skulle ju säkert en polett trilla ner. 
Jättebra med livekodningarna och hoppas det blir mer utav det för det behövs verkligen tycker jag!


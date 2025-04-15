namespace NumberAndNameGenerator
{
    /// <summary>
    /// This class represents a name with a first and last name.    
    /// </summary>
    /// <param name="FirstName" > The first name of the person.</param>
    /// <param name="LastName" > The last name of the person.</param>
    public class Name(string FirstName, string LastName)
    {
        /// <summary>
        /// The first name of the person.
        /// </summary>
        public string FirstName { get; set; } = FirstName;
        /// <summary>
        /// The last name of the person.
        /// </summary>
        public string LastName { get; set; } = LastName;
    }
}

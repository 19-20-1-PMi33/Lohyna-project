using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace Repositories.Persons
{
    /// <summary>
    /// Service for obtaining person info.
    /// </summary>
    public interface IPersonRepository
    {
        /// <summary>
        /// Load person.
        /// </summary>
        /// <param name="name">Username of a person.</param>
        /// <returns>List of people with given username.</returns>
        Task<List<Person>> LoadPersonAsync(string name);

        /// <summary>
        /// Update person data in data source.
        /// </summary>
        /// <param name="person">Person to be updated.</param>
        /// <returns>Status of operation.</returns>
        void UpdatePersonInfo(Person person);

        /// <summary>
        /// Load person that try to log in.
        /// </summary>
        /// <param name="username">Person's username.</param>
        /// <returns>Person with given username.</returns>
        Person LoadLogInPersonAsync(string username);

        /// <summary>
        /// Load student for given person.
        /// </summary>
        /// <param name="person">Related person.</param>
        /// <returns>Student info.</returns>
        Student LoadStudent(Person person);

        /// <summary>
        /// Load lecture info for given person.
        /// </summary>
        /// <param name="person">Related person.</param>
        /// <returns>Lecturer info.</returns>
        Lecturer LoadLecturer(Person person);

        /// <summary>
        /// Save person in data source.
        /// </summary>
        /// <param name="person">Person to be saved.</param>
        /// <returns>Status of operation.</returns>
        Task CreatePersonAsync(Person person);
        /// <summary>
        /// Save student in data source
        /// </summary>
        /// <param name="student">Student to be saved</param>
        /// <returns>Status of operation.</returns>
        Task CreateStudentAsync(Student student);

        /// <summary>
        /// Load people with given name.
        /// </summary>
        /// <param name="name">Name of people.</param>
        /// <returns>List of people with given name.</returns>
        Task<List<Person>> SearchPersonByNameAsync(string name);

        /// <summary>
        /// Load people with given surname.
        /// </summary>
        /// <param name="surname">Surname to be searched.</param>
        /// <returns>List of people with given surname.</returns>
        Task<List<Person>> SearchPersonBySurnameAsync(string surname);
        
        /// <summary>
        /// Load lecturer by given ID.
        /// </summary>
        /// <param name="LecturerID">id of lecturer to search</param>
        /// <returns></returns>
        Lecturer SearchLecturerById(int LecturerID);

        /// <summary>
        /// Create lecturer and store in db.
        /// </summary>
        /// <param name="lecturer">Lecturer to save.</param>
        void CreateLecturerAsync(Lecturer lecturer);
        bool ContainsPerson(Person p);
        Achievment LoadLastAchievmentForStudent(Student student);
    }
}
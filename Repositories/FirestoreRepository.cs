using Google.Cloud.Firestore;
using Microsoft.CodeAnalysis;

namespace PFCWebApplication.Repositories
{
    public class FirestoreRepository
    {
        FirestoreDb db;
        public FirestoreRepository(string project) {
            //code that initializes the firestore db
            db = FirestoreDb.Create(project);
        }

        public async void AddUser(string email, string firstName, string lastName) {

            DocumentReference docRef = db.Collection("users").Document(email);
            Dictionary<string, object> user = new Dictionary<string, object>
            {
                { "email", email },
                { "firstName", firstName},
                { "lastName", lastName }
            };

            //it saving the user asynchronously...
             await docRef.SetAsync(user);

        }

        public async Task<bool> DoesUserExist(string email)
        {
            DocumentReference docRef = db.Collection("users").Document(email);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            if (snapshot.Exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        



    }
}

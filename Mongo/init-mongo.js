db.createUser(
    {
        user : "usr",
        pwd : "pass",
        roles : [
            {
                role : "readWrite",
                db : "library"
            }
        ]
    }
)
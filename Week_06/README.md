### Week 6 code examples

**EditDeletePattern**

Implementing the edit and delete coding patterns.

Features:
- data annotations help drive the display and error messages
- and also - obviously - input data validation
- study the edit pattern rhythm; two methods are required
- also study the delete pattern rhythm
- notice the "Details.cshtml" view uses TempData for an edit/delete status message

**ManyToMany**

Introduction to many-to-many assocations.

Features:
- problem domain is "movies" and "actors"
- each entity has a collection of the other entity

**SelfOneToMany**

Introduction to self-referencing one-to-many associations.

Features:
- problem domain is "employees"
- an employee can have a supervisor
- an employee can supervise other employees

**OneToOne**

Introduction to one-to-one associations.

Features:
- problem domain is "employees", who may have one or two "addresses"
- an address cannot exist on its own - it must be associated with an employee

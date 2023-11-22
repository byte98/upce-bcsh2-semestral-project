     
     
     
     
     
     /* CRUD operations over 'staty' table */
                    
    /*
     * Type definition of data stored in 'staty' table
     */
--

    /*
     * Creates new 'staty' object.
     * :param p_name: Name of new 'staty' object.
     */
--

    /*
     * Updates 'staty' object.
     * :param p_id:   Identifier of object which will be updated.
     * :param p_name: New name of object.
     */
--

    /*
     * Deletes 'staty' object.
     * :param p_id: Identifier of object which will be deleted.
     */
--

    /*
     * Reads all data from 'staty'.
     * :returns: Table with all data from 'staty'.
     */
--

    /*
     * Reads searched data from 'staty'.
     * :param p_id: Identifier of searched data.
     * :returns:    Table with data from 'staty' with searched identifier.
     */
--

    /*
     * Reads searched data from 'staty'.
     * :param p_name: Name of searched data.
     * :returns:      Table with data from 'staty' with searched name.
     */
--





    /* CRUD operations over 'obce' table */

    /*
     * Type definition of data stored in 'obce' table.
     */
--

    /*
     * Creates new 'obce' object.
     * :param p_name:    Name of new object.
     * :param p_zip:     ZIP code of new object.
     * :param p_country: Identifier of country in which is 'obce' object located.
     */
--

    /*
     * Creates new 'obce' object.
     * :param p_name:    Name of new object.
     * :param p_part:    Name of part of new object.
     * :param p_zip:     ZIP code of new object.
     * :param p_country: Identifier of country in which is 'obce' object located.
     */
--
                    
    /*
     * Updates 'obce' object.
     * :param p_id:      Identifier of object which will be updated.
     * :param p_name:    New name of object.
     * :param p_zip:     New ZIP code of object.
     * :param p_country: New identifier of country in which is 'obce' object located.
     */
--
                    
    /*
     * Updates 'obce' object.
     * :param p_id:      Identifier of object which will be updated.
     * :param p_name:    New name of object.
     * :param p_zip:     New ZIP code of object.
     * :param p_country: New identifier of country in which is 'obce' object located.
     */
--
    
    /*
     * Deletes 'obce' object.
     * :param p_id: Identifier of object which will be deleted.
     */
--

    /*
     * Reads all data from table 'obce'.
     * :returns: Table with all data from table 'obce'.
     */
--

    /*
     * Reads searched data from 'obce'.
     * :param p_id: Identifier of searched object.
     * :returns:    Table with all searched data from table 'obce'.
     */
--





    /* CRUD operations over 'adresy' table */

    /*
     * Type definition of data stored in 'adresy' table.
     */
--

    /*
     * Creates new object 'adresy'.
     * :param p_street:       Name of street.
     * :param p_home:         Number of home.
     * :param p_municipality: Identifier of 'obce' in which is 'adresy' located.*
     */
--
    
    /*
     * Creates new object 'adresy'.
     * :param p_street:       Name of street.
     * :param p_home:         Number of home.
     * :param p_orientation:  Orientational number of home.
     * :param p_municipality: Identifier of 'obce' in which is 'adresy' located.*
     */
--
    
    /*
     * Creates new object 'adresy'
     * :param p_home:         Number of home.
     * :param p_municipality: Identifier of 'obce' in which is 'adresy' located.
     */
--
    
    /*
     * Creates new object 'adresy'
     * :param p_home:         Number of home.
     * :param p_orientation:  Orientational number of home.
     * :param p_municipality: Identifier of 'obce' in which is 'adresy' located.
     */
--
    
    /* Updates 'adresy' object.
     * :param p_id:           Identifier of object which will be updated.
     * :param p_street:       New street of object.
     * :param p_home:         New number of home of object.
     * :param p_municipality: New identifier of 'obce' in which is 'adresy' located.
     */
--
    
    /* Updates 'adresy' object.
     * :param p_id:           Identifier of object which will be updated.
     * :param p_street:       New street of object.
     * :param p_home:         New number of home of object.
     * :param p_orientation:  New orientational number of home of object.
     * :param p_municipality: New identifier of 'obce' in which is 'adresy' located.
     */
--
    
    /* Updates 'adresy' object.
     * :param p_id:           Identifier of object which will be updated.
     * :param p_home:         New number of home of object.
     * :param p_municipality: New identifier of 'obce' in which is 'adresy' located.
     */
--
    
    /* Updates 'adresy' object.
     * :param p_id:           Identifier of object which will be updated.
     * :param p_home:         New number of home of object.
     * :param p_orientation:  New orientational number of home of object.
     * :param p_municipality: New identifier of 'obce' in which is 'adresy' located.
     */
--
    
    /*
     * Deletes 'adresy' object.
     * :param p_id: Identifier of object which will be deleted.
     */
--

    /*
     * Reads all data from 'adresy' table.
     * :returns: Table with data from 'adresy' table.
     */
--

    /*
     * Reads searched data from 'adresy' table.
     * :param p_id: Identifier of searched data.
     * :returns:    Table with searched data from 'adresy' table.
     */
--




    /* CRUD operations over 'osoby' table */

    /*
     * Type definition of data stored in 'osoby' table.
     */
--
    
    /*
     * Creates new 'osoby' object.
     * :param p_name:    Name of new 'osoby'.
     * :param p_surname: Surname of new 'osoby'.
     * :param p_email:   E-mail of new 'osoby'.
     * :param p_phone:   Phone number of new 'osoby'.
     */
--

    /*
     * Updates 'osoby' object.
     * :param p_id:      Identifier of 'osoby' which will be updated.
     * :param p_name:    New name of 'osoby'.
     * :param p_surname: New surname of 'osoby'.
     * :param p_email:   New e-mail of 'osoby'.
     * :param p_phone:   New phone number of 'osoby'.
     */
--

    /*
     * Deletes data from 'osoby'.
     * :param p_id: Identifier of 'osoby' which will be deleted.
     */
--

    /*
     * Reads all data from 'osoby'.
     * :returns: Table with data from 'osoby'.
     */
--

    /*
     * Reads specified data from 'osoby'.
     * :param p_id: Identifier of searched data.
     * :returns:    Table with data from 'osoby' which has specified identifier.
     */
--
    
    
     
    
    
    /* CRUD operations over 'zamestnanci' table. */

    /*
     * Type definition of table 'zamestnanci'.
     */
--
    
    /*
     * Creates new object 'zamestnanci'.
     * :param p_personal_number: Personal number of new 'zamestnanci' object.
     * :param p_date:            Start of employment of new 'zamestnanci' object.
     * :param p_residence:       Identifier of address from 'adresy' of residence of new 'zamestnanci' object.
     * :param p_personal_data:   Identifier of personal data from 'osoby' of new 'zamestnanci' object.
     */
--

    /*
     * Creates new object 'zamestnanci'.
     * :param p_personal_number: Personal number of new 'zamestnanci' object.
     * :param p_date:            Start of employment of new 'zamestnanci' object.
     * :param p_residence:       Identifier of address from 'adresy' of residence of new 'zamestnanci' object.
     * :param p_personal_data:   Identifier of personal data from 'osoby' of new 'zamestnanci' object.
     * :param p_superior:        Identifier of superior employee from 'zamestnanci' of new 'zamestnanci' object.
     */
--

    /*
     * Updates 'zamestnanci'.
     * :param p_id:              Identifier of 'zamestanci' object which will be updated.
     * :param p_personal_number: New personal number of 'zamestnanci' object.
     * :param p_date:            New sart of employment of 'zamestnanci' object.
     * :param p_residence:       New identifier of address from 'adresy' of residence of 'zamestnanci' object.
     * :param p_personal_data:   New identifier of personal data from 'osoby' of 'zamestnanci' object.
     */
--

    /*
     * Updates 'zamestnanci'.
     * :param p_id:              Identifier of 'zamestanci' object which will be updated.
     * :param p_personal_number: New personal number of 'zamestnanci' object.
     * :param p_date:            New sart of employment of 'zamestnanci' object.
     * :param p_residence:       New identifier of address from 'adresy' of residence of 'zamestnanci' object.
     * :param p_personal_data:   New identifier of personal data from 'osoby' of 'zamestnanci' object.
     * :param p_superior:        New identifier of superior employee from 'zamestnanci' of 'zamestnanci' object.
     */
--

    /*
     * Deletes data from 'zamestnanci'.
     * :param p_id: Identifier of 'zamestnanci' which will be deleted.
     */
--

    /*
     * Function which reads all available data from 'zamestnanci'.
     * :returns: Table with data from 'zamestnanci'.
     */
--

    /*
     * Function which reads data from 'zamestnanci' defined by its identifier.
     * :param p_id: Identifier of searched data.
     * :returns:    Table with data from 'zamestnanci' with searched identifier.
     */
--





    /* CRUD operations over 'role' table. */
    
    /*
     * Type definition of table with data from 'role'.
     */
--

    /*
     * Creates object 'role'.
     * :param p_name: Name of new 'role' object.
     */
--

    /*
     * Updates object 'role'.
     * :param p_id:   Identifier of object which will be updated.
     * :param p_name: New name of 'role'.
     */
--

    /*
     * Deletes object from 'role'.
     * :param p_id: Identifier of object which will be deleted.
     */
--

    /*
     * Reads all available data from 'role'.
     * :returs: Table with all data from 'role'.
     */
--
        
    /*
     * Reads searched data from 'role'.
     * :param p_id: Identifier of searched data.
     * :returns:    Table with searched data from 'role'.
     */
--

    



    /* CRUD operations over 'stavy' table. */

    /*
     * Type definition of table with data from 'stavy'.
     */
--

    /*
     * Creates new 'stavy' object.
     * :param p_name: Name of new 'stavy' object.
     */
--

    /*
     * Updates 'stavy' object.
     * :param p_id:   Identifier of object which will be updated.
     * :param p_name: New name of 'stavy' object.
     */
--
    
    /*
     * Deletes object 'stavy'.
     * :param p_id: Identifier of object which will be deleted.
     */
--

    /*
     * Reads all data from 'stavy'.
     * :returns: Table with all data from 'stavy'.
     */
--

    /*
     * Reads searched data from 'stavy'.
     * :param p_id: Identifier of searched data.
     * :returns:    Table with searched data from 'stavy'.
     */
    





    /* CRUD operations over 'uzivatele' table. */

    /*
     * Type definition of table of 'uzivatele'.
     */
--
    
    /*
     * Creates new 'uzivatele' object.
     * :param p_pwd:   Password of new 'uzivatele'.
     * :param p_reg:   Date and time of registration of new 'uzivatele'.
     * :param p_pict:  Picture of new 'uzivatele'.
     * :param p_role:  Identifier of 'role' of new 'uzivatele'.
     * :param p_state: Identifier of 'stavy' of new 'uzivatele'.
     * :param p_empl:  Identifier of 'zamestnanci' to which is new 'uzivatele' assigned to.
     */
--

    /*
     * Updates 'uzivatele' object.
     * :param p_id:    Identifier of 'uzivatele' which will be updated.
     * :param p_pwd:   New password of 'uzivatele'.
     * :param p_reg:   New date and time of registration of 'uzivatele'.
     * :param p_pict:  New picture of 'uzivatele'.
     * :param p_role:  New identifier of 'role' of 'uzivatele'.
     * :param p_state: New identifier of 'stavy' of 'uzivatele'.
     * :param p_empl:  New identifier of 'zamestnanci' to which is 'uzivatele' assigned to.
     */
--

    /*
     * Deletes object from 'uzivatele'.
     * :param p_id: Identifier of object which will be deleted.
     */
--

    /*
     * Reads all available data from 'uzivatele'.
     * :returns: Table with all data from 'uzivatele'.
     */
--

    /*
     * Reads all searched data from 'uzivatele'.
     * :param p_id: Identifier of searched data.
     * :returns:    Table with all searched from 'uzivatele'.
     */
--

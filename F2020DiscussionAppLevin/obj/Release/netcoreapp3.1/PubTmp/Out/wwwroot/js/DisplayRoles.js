function DisplayRoles() {

    var inputUrl = '/AppUser/GetCurrentRoles';
    var checkBoxName = 'currentRoles';
    var rolesTarget = '#currentRolesTarget';
    GetRolesForUser(inputUrl, checkBoxName, rolesTarget);

     inputUrl = '/AppUser/GetAvailableRoles';
     checkBoxName = 'availableRoles';
    rolesTarget = '#availableRolesTarget';
    GetRolesForUser(inputUrl, checkBoxName, rolesTarget);


}
function GetRolesForUser(dataUrl, checkBoxName, rolesTarget) {

    var listRoles = $(rolesTarget);
    var usersTarget = $('#usersTarget').val();

    $.getJSON(
        {
            url: dataUrl,
            data: { id: usersTarget }, 
            success: function (data) {
                listRoles.empty();
                $.each(data, function () {
                    //listRoles.append('<input type="checkbox" name = "' + checkBoxName + '" value = "' + this.Name + '">' + this.Name + '</br>');
                    listRoles.append('<option value="' + this.Name + '"> ' + this.Name + ' </option>');
                }
                );
            },
            error: function () {
                alert('Data not received');
            }
        }
    );

}
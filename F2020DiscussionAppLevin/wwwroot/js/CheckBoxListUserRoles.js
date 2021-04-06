$(document).ready(function () {

    if ($('#usersTarget').val() != 'None') {
        $('#wrapper').show();
        DisplayRoles();
    }
    else {
        $('#wrapper').hide();
    }

    $('#usersTarget').change(function () {
        if ($('#usersTarget').val() != 'None') {
            $('#wrapper').show();
            DisplayRoles();
        }
        else {
            $('#wrapper').hide();
        }

    }

    );
}
    );
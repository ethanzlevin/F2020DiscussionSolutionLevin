$(document).ready(

    function ()
    {
        $('#numberOfVolunteerHoursGroup').hide();

        $('#userRole').change(
            function ()
            {

                var userRole = $('#userRole').val();

                if (userRole == 'Volunteer') {

                    $('#numberOfVolunteerHoursGroup').show();

                }
                else {
                    
                    $('#numberOfVolunteerHoursGroup').hide();

                }
            }
        );
    }
);
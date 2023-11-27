
$(document).ready(function () {
    var username = '@username'; // Get the username from the server or set it from the session)
    // Make an AJAX call to get user details
    $.ajax({
        url: '/User/GetUserDetails',
        type: 'GET',
        data: { username: username },
        success: function (user) {
            // Update the UI with user details
            $('#userFullName').text('Name: ' + user.firstName + ' ' + user.lastName);
            $('#userEmail').text('Email: ' + user.email);
            $('#userPhoneNumber').text('Phone Number: ' + user.phoneNumber);
        },
        error: function () {
            console.log('Error fetching user details.');
        }
    });
});

function completePurchase() {
    event.preventDefault(); // Prevent the default form submission
    // Assume you are using jQuery for simplicity
    var address = $('#address').val();

    var form = document.getElementById('checkoutForm');
    if (form.checkValidity() === false) {
        event.preventDefault();
        event.stopPropagation();
        form.classList.add('was-validated');
        return;
    }

    $.ajax({
        url: '/Checkout/CompletePurchase',
        type: 'POST',
        data: { address: address },

        success: function (response) {
            if (response.success) {
                console.log("here")
                location.reload();
            }
        }
    });
}
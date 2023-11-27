function loginToSite(event) {
    event.preventDefault(); // Prevent the default form submission

    var form = document.getElementById('loginForm');

    if (form.checkValidity() === false) {
        event.preventDefault();
        event.stopPropagation();
        form.classList.add('was-validated');
        return;
    }

    var formData = $('#loginForm').serialize();

    // Make AJAX request
    $.ajax({
        url: '/Login/Login', // Replace with your actual controller and action
        type: 'POST',
        data: formData,

        success: function (response) {
            if (response.success) {
                // Redirecting to the home page
                window.location.href = 'http://localhost:7129/';
            } else {
                if (response.errors) {
                    // Display validation errors
                    alert('Validation failed: ' + response.errors.join(', '));
                } else {
                    // Display other errors
                    alert('An error occurred: ' + response.message);
                }
            }
        },
    });
}
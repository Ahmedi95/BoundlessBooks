function saveUserDetails(event) {
    event.preventDefault(); // Prevent the default form submission

    var form = document.getElementById('registrationForm');

    if (form.checkValidity() === false) {
        event.preventDefault();
        event.stopPropagation();
        form.classList.add('was-validated');
        return;
    }

    var formData = $('#registrationForm').serialize();

    // Make AJAX request
    $.ajax({
        url: '/Register/RegisterUser', // Replace with your actual controller and action
        type: 'POST',
        data: formData,

        success: function (response) {
            if (response.success) {
                window.location.href = '/Login/Index';
            } else {
                if (response.errors) {
                    // Display validation errors
                    alert('Validation failed: ' + response.errors.join(', '));
                } else {
                    // Display other errors
                    alert('An error occurred: ' + response.message);
                }
            }
        }
    });
}
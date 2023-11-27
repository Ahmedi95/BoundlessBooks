// searchBooks.js
function searchBooks(event) {
    if (event.key === 'Enter') {
        var searchQuery = $('#searchQueryInput').val();

        $.ajax({
            url: '/Home/Search',
            type: 'GET',
            data: { searchQuery: searchQuery },
            success: function (response) {
                // Update the book list container with the response HTML
                $('#bookListContainer').html(response);
            },
        });
    }
}

// Keypress event for the search input
$("#searchQueryInput").keypress(searchBooks);

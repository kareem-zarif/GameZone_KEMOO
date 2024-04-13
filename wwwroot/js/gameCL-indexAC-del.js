$(document).ready(function () {
    $('.custom-js-delete').on('click', function () {
        var theBtn = $(this);

        //Swwetalert2 online libaray https://sweetalert2.github.io/
        const swalWithBootstrapButtons = Swal.mixin({
            customClass: {
                confirmButton: "btn btn-danger",
                cancelButton: "btn btn-outline-success"
            },
            buttonsStyling: false
        });
        swalWithBootstrapButtons.fire({
            title: "Are you sure?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Yes, delete it!",
            cancelButtonText: "No, cancel!",
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `/Games/Delete/${theBtn.data('id')}`,

                    method: 'DELETE',

                    success: function () {
                        swalWithBootstrapButtons.fire({
                            title: "Deleted!",
                            text: "Game has been deleted.",
                            icon: "success"
                        });
                        //remove the row from the page without refresh 
                        theBtn.parents('tr').fadeOut();
                    },
                    error: function () {
                        swalWithBootstrapButtons.fire({
                            title: "Oooooooops!",
                            text: "Game failed to be deleted.",
                            icon: "Failed"
                        });
                    }
                });

                
            }
            
        });

        
    })
});
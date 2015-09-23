<div class="footer">

			<div class="container">
				<a href="mailto:bampis.s@gmail.com" class="btn-info  btn  col-md-2 col-md-offset-5">Επικοινωνήστε μαζί μας</a><br/>
				<span id="pelatisNotification" class="row">
					
				</span>
			</div>

		</div>

		<script>
			

$("#mainTable").on("click", "td", function() {
     var a = $(this).html();
				//alert(a);
				 $.ajax({
            type:"POST",
            url:"findPelatisName",
            data:{p_id:a},
            success:function(data){
            var b = jQuery.parseJSON(data)
            $('#pelatisNotification').html("<span class=col-md-6 col-md-offset-3>Πελάτης:"+b.Epitheto+" " +b.Onoma+" </span>");
           
              // alert(data);   	
				        }      
				        });
				// alert(a);
   });
			


		</script>
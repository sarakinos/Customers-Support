

@extends('layouts.default')


@section('content')
<div class="jumbotron">
				<h2>Λειτουργίες</h2>
				
			</div>
			<p>
				<span>
					<button id="sendMail" type="button" class="btn btn-info btn-lg btn-block" >Αποστολή Email</button>
				</span>
				</p>

				<div id="mailScreen" >
	
					<div class="table-responsive ">
		    				 <table id="mainTable" class="table table-bordered ">
		    					<thead>
		    						<tr>
		    								<th>ID</th>
		    								<th>Όνομα</th>
		    								<th>Επίθετο</th>
		    								<th>Email</th>
		    								<th>Επιλογή</th>
		    						</tr>
		    					</thead>
		    					 <tbody>
							    @foreach($pelates as $pelatis)
							       <tr>
							       		<td>{{$pelatis->p_id}}</td>
							       		<td>{{$pelatis->Onoma}}</td>
							       		<td>{{$pelatis->Epitheto}}</td>
							       		<td>{{$pelatis->Email}}</td>
							       		<td class="text-center"><input type="checkbox"/></td>
							      </tr>
							    @endforeach
							    </tbody>
							</table>
						</div>
						<div class="container text-center">
							<textarea id="mes" name="message" placeholder="Εισάγετε το μήνυμα εδώ..." cols=25 rows=10>

							</textarea><br/>
							<button type="button" class="btn btn-success" id="sendMailButton"> Αποστολή</button>
						</div>
					

				</div>

<script>

	var emailList = [];

	$('#mailScreen').hide();

	$('#sendMail').on('click',function(){
		$('#mailScreen').toggle();
	});

$('#mainTable').click(function(){
	emailList = [];
	$('#mainTable tr').filter(':has(:checkbox:checked)').find('td:eq(3)').each(function() {
    // this = td element

    var item = $(this).text();
    var found=0;

    for(var i=0;i<emailList.length;i++){
    	if(emailList[i]==item) found=1;
    }

    if(found==0) emailList.push(item); 
   
});


});
	
	$('#sendMailButton').click(function(){
		 //alert(emailList);
		 var mes = $('#mes').val();
		$.ajax({
            type:"POST",
            url:"sendMail",
            data:{list:emailList,message:mes},
            success:function(data){
            
             console.log(data);
             
             	
        }


            
        });
	});

</script>


@stop



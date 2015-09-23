

@extends('layouts.default')


@section('content')
<div class="jumbotron">
				<h2>Διαχείρηση Ραντεβού</h2>
				@include('includes.menu_leitourgies')
				@if(Request::path() == 'rantevou')
				<div id="rantevouShow" >
								<div class="table-responsive">
		    				 	<table id="mainTable" class="table table-bordered ">
		    				 		<thead>
		    						<tr>
		    								<th>ID</th>
		    								<th>Πελάτης</th>
		    								<th>Αίτημα</th>
		    								<th>Θέμα</th>
		    								<th>Ημερομηνία</th>
		    								<th>Κρισιμότητα</th>
		    								<th>Σχόλια</th>		    							
		    						</tr>
		    					</thead>
		    					 <tbody> 
    				@foreach($rantevou as $rant)  

							       <tr>
							       		<td>{{$rant->rant_id}}</td>
							       		<td style="cursor: pointer;">{{$rant->p_id}}</td>
							       		<td>{{$rant->ait_id}}</td>
							       		<td>{{$rant->Thema}}</td>
							       		<td>{{$rant->Hmerominia}}</td>
							       		<td>{{$rant->Krisimotita}}</td>
							       		<td>{{$rant->Sxolia}}</td>

							       		
							      </tr>
							    @endforeach
							</tbody>
						</table>
							</div>
						</div>
					
				

<div id="rantevouAdd" >
								<form action="rantevouAdd" method="post">
									<div class=form-group>
    						<label for=rant_id>ID</label>
   								<input type=number class=form-control name=rant_id readonly>
  						</div>
								<div class=form-group>
    						<label for=p_id>Πελάτης</label>
   								<input type=number class=form-control name=p_id >
  						</div>
  						<div class=form-group>
						    <label for=ait_id>Αίτημα</label>
						    	<input type=number class=form-control name=ait_id>
  						</div>
  						<div class=form-group>
    						<label for=Thema>Θέμα</label>
   								<input type=text class=form-control name=Thema >
  						</div>
  						<div class=form-group>
						    <label for=Hmerominia>Ημερομινία</label>
						    	<input type=datetime-local class=form-control name=Hmerominia>
  						</div>
  						<div class=form-group>
						    <label for=Sxolia>Σχόλια</label>
						    	<input type=text class=form-control name=Sxolia>
  						</div>
  						<div class=form-group>
    						<label for=Krisimotita>Κρισιμότητα</label>
   								<input type=number class=form-control name=Krisimotita min="1" max="3">
  						</div>
  						
  						
		<input class="btn btn-success" type="submit" value="Καταχώρηση"/>
		<input class="btn btn-info" type="reset" value="Καθαρισμός"/>
	</form>


						</div>

						<div id="rantevouEditUpdate">
							<form action="rantevouEditUpdate" method="post">
							<div class=form-group>
    						<label for=rant_id>ID</label>
   								<input type=number class=form-control name=rant_id readonly>
  						</div>
								<div class=form-group>
    						<label for=p_id>Πελάτης</label>
   								<input type=number class=form-control name=p_id >
  						</div>
  						<div class=form-group>
						    <label for=ait_id>Αίτημα</label>
						    	<input type=number class=form-control name=ait_id>
  						</div>
  						<div class=form-group>
    						<label for=Thema>Θέμα</label>
   								<input type=text class=form-control name=Thema >
  						</div>
  						<div class=form-group>
						    <label for=Hmerominia>Ημερομινία</label>
						    	<input type=datetime-local class=form-control name=Hmerominia>
  						</div>
  						<div class=form-group>
						    <label for=Sxolia>Σχόλια</label>
						    	<input type=text class=form-control name=Sxolia>
  						</div>
  						<div class=form-group>
    						<label for=Krisimotita>Κρισιμότητα</label>
   								<input type=number class=form-control name=Krisimotita min="1" max="3">
  						</div>
		<input class="btn btn-success" type="submit" value="Καταχώρηση"/>
		<input class="btn btn-info" type="reset" value="Καθαρισμός"/>
	</form>
						</div>

						<div id="rantevouDelete" >
							{{Form::open(['url'=>'rantevouDelete'])}}
								{{Form::label('rant_id','ID')}}
								{{Form::input('number','rant_id')}}
								{{Form::submit('Διαγραφή',['class' => 'btn  btn-success'])}}
							{{Form::close()}}
						</div>

@endif
			</div>


<script>
	$(document).ready(function(){

		hideAll()
	
	});

$("#provoli").click(function(){
	hideAll();
	$("#rantevouShow").show();
});

$("#kataxorisi").click(function(){
	hideAll();
	$("#rantevouAdd").show();
});

$("#epeksergasia").click(function(){
	hideAll();
	$("#rantevouEditUpdate").show();
});

$("#diagrafi").click(function(){
	hideAll();
	$("#rantevouDelete").show();
});


function hideAll(){
	
		$("#rantevouEditUpdate").hide();
		$("#rantevouDelete").hide();
		$("#rantevouAdd").hide();
}

$("tr").click(function(){
	var a = $(this).closest('tr').find('td:first').text();

 $.ajax({
            type:"POST",
            url:"rantevouEdit",
            data:{rant_id:a},
            success:function(data){
            var b = jQuery.parseJSON(data)
            $('input[name=rant_id]').val(b.rant_id);
            $('input[name=p_id]').val(b.p_id);
            $('input[name=ait_id]').val(b.ait_id);
            $('input[name=Krisimotita]').val(b.Krisimotita);
            $('input[name=Sxolia]').val(b.Sxolia);
            b.Hmerominia = b.Hmerominia.replace(" ", "T");
            //alert(b.Hmerominia);
            $('input[name=Hmerominia]').val(b.Hmerominia);
            $('input[name=Thema]').val(b.Thema);
    
           
              // alert(data);
             
             	
        }


            
        });

});

</script>

@stop


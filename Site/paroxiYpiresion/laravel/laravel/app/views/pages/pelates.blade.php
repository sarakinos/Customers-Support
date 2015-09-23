

@extends('layouts.default')


@section('content')

<div class="jumbotron">
				<h2>Διαχείρηση Πελατών</h2>
				@include('includes.menu_leitourgies')

				@if(Request::path() == 'pelates')
				<div id="pelatesShow" >
					<div class="table-responsive ">
		    				 <table id="mainTable" class="table table-bordered ">
		    					<thead>
		    						<tr>
		    								<th>ID</th>
		    								<th>Όνομα</th>
		    								<th>Επίθετο</th>
		    								<th>Όνομα Μητέρας</th>
		    								<th>Ημερομηνία Γέννησης</th>
		    								<th>Τηλέφωνο Οικίας</th>
		    								<th>Κινητό</th>
		    								<th>Διεύθηνση</th>
		    								<th>Δήμος</th>
		    								<th>Περιφέρια</th>
		    								<th>Περιφεριακή Ενότητα</th>
		    								<th>Επάγγελμα</th>
		    								<th>Email</th>
		    						</tr>
		    					</thead>
		    					 <tbody>
							    @foreach($pelates as $pelatis)
							       <tr>
							       		<td>{{$pelatis->p_id}}</td>
							       		<td>{{$pelatis->Onoma}}</td>
							       		<td>{{$pelatis->Epitheto}}</td>
							       		<td>{{$pelatis->Onoma_Miteras}}</td>
							       		<td>{{$pelatis->Hmerominia_Gennisis}}</td>
							       		<td>{{$pelatis->Tilefono_Oikias}}</td>
							       		<td>{{$pelatis->Kinito_Tilefono}}</td>
							       		<td>{{$pelatis->Diefthinsi}}</td>
							       		<td>{{$pelatis->Dimos}}</td>
							       		<td>{{$pelatis->Periferia}}</td>
							       		<td>{{$pelatis->Periferiaki_Enotita}}</td>
							       		<td>{{$pelatis->Epaggelma}}</td>
							       		<td>{{$pelatis->Email}}</td>
							      </tr>
							    @endforeach
							    </tbody>
							</table>
						</div>
						</div>




						<div id="pelatesAdd" >
								<form action="pelatisAdd" method="post">
									<div class=form-group>
    						<label for=p_id>ID</label>
   								<input type=text class=form-control name=p_id readonly >
  						</div>
								<div class=form-group>
    						<label for=Onoma>Όνομα</label>
   								<input type=text class=form-control name=Onoma >
  						</div>
  						<div class=form-group>
						    <label for=Epitheto>Επίθετο</label>
						    	<input type=text class=form-control name=Epitheto>
  						</div>
  						<div class=form-group>
    						<label for=Onoma_Miteras>Όνομα Μητέρας</label>
   								<input type=text class=form-control name=Onoma_Miteras>
  						</div>
  						<div class=form-group>
						    <label for=Onoma_Patera>Όνομα Πατέρα</label>
						    	<input type=text class=form-control name=Onoma_Patera>
  						</div>
  						<div class=form-group>
    						<label for=Hmerominia_Gennisis>Ημερομηνία Γέννησης</label>
   								<input type=date class=form-control name=Hmerominia_Gennisis>
  						</div>
  						<div class=form-group>
						    <label for=Tilefono_Oikias>Τηλέφωνο Οικίας</label>
						    	<input type=number class=form-control name=Tilefono_Oikias>
  						</div>
  						<div class=form-group>
						    <label for=Kinito_Tilefono>Κινητό Τηλέφωνο</label>
						    	<input type=number class=form-control name=Kinito_Tilefono>
  						</div>
  						<div class=form-group>
    						<label for=Diefthinsi>Διεύθηση</label>
   								<input type=text class=form-control name=Diefthinsi>
  						</div>
  						<div class=form-group>
						    <label for=Dimos>Δήμος</label>
						    	<input type=text class=form-control name=Dimos>
  						</div>
  						<div class=form-group>
    						<label for=Periferia>Περιφέρια</label>
   								<input type=text class=form-control name=Periferia>
  						</div>
  						<div class=form-group>
						    <label for=Periferiaki_Enotita>Περιφεριακή Ενότητα</label>
						    	<input type=text class=form-control name=Periferiaki_Enotita>
  						</div>
  						<div class=form-group>
    						<label for=Epaggelma>Επάγγελμα</label>
   								<input type=text class=form-control name=Epaggelma>
  						</div>
  						<div class=form-group>
						    <label for=Email>Email</label>
						    	<input type=email class=form-control name=Email>
  						</div>
		<input class="btn btn-success" type="submit" value="Καταχώρηση"/>
		<input class="btn btn-info" type="reset" value="Καθαρισμός"/>
	</form>


						</div>

						<div id="pelatesEditUpdate">
							<form action="pelatisEditUpdate" method="post">
								<div class=form-group>
    						<label for=p_id>ID</label>
   								<input type=text class=form-control name=p_id readonly >
  						</div>
								<div class=form-group>
    						<label for=Onoma>Όνομα</label>
   								<input type=text class=form-control name=Onoma >
  						</div>
  						<div class=form-group>
						    <label for=Epitheto>Επίθετο</label>
						    	<input type=text class=form-control name=Epitheto>
  						</div>
  						<div class=form-group>
    						<label for=Onoma_Miteras>Όνομα Μητέρας</label>
   								<input type=text class=form-control name=Onoma_Miteras>
  						</div>
  						<div class=form-group>
						    <label for=Onoma_Patera>Όνομα Πατέρα</label>
						    	<input type=text class=form-control name=Onoma_Patera>
  						</div>
  						<div class=form-group>
    						<label for=Hmerominia_Gennisis>Ημερομηνία Γέννησης</label>
   								<input type=date class=form-control name=Hmerominia_Gennisis>
  						</div>
  						<div class=form-group>
						    <label for=Tilefono_Oikias>Τηλέφωνο Οικίας</label>
						    	<input type=number class=form-control name=Tilefono_Oikias>
  						</div>
  						<div class=form-group>
						    <label for=Kinito_Tilefono>Κινητό Τηλέφωνο</label>
						    	<input type=number class=form-control name=Kinito_Tilefono>
  						</div>
  						<div class=form-group>
    						<label for=Diefthinsi>Διεύθηση</label>
   								<input type=text class=form-control name=Diefthinsi>
  						</div>
  						<div class=form-group>
						    <label for=Dimos>Δήμος</label>
						    	<input type=text class=form-control name=Dimos>
  						</div>
  						<div class=form-group>
    						<label for=Periferia>Περιφέρια</label>
   								<input type=text class=form-control name=Periferia>
  						</div>
  						<div class=form-group>
						    <label for=Periferiaki_Enotita>Περιφεριακή Ενότητα</label>
						    	<input type=text class=form-control name=Periferiaki_Enotita>
  						</div>
  						<div class=form-group>
    						<label for=Epaggelma>Επάγγελμα</label>
   								<input type=text class=form-control name=Epaggelma>
  						</div>
  						<div class=form-group>
						    <label for=Email>Email</label>
						    	<input type=email class=form-control name=Email>
  						</div>
		<input class="btn btn-success" type="submit" value="Καταχώρηση"/>
		<input class="btn btn-info" type="reset" value="Καθαρισμός"/>
	</form>
						</div>

						<div id="pelatesDelete" >
							{{Form::open(['url'=>'pelatisDelete'])}}
								{{Form::label('p_id','ID')}}
								{{Form::input('number','p_id')}}
								{{Form::submit('Διαγραφή',['class' => 'btn  btn-success'])}}
							{{Form::close()}}
						</div>
				@endif

<div id="test">
</div>

<script>
	$(document).ready(function(){

		hideAll()
	
	});

$("#provoli").click(function(){
	hideAll();
	$("#pelatesShow").show();
});

$("#kataxorisi").click(function(){
	hideAll();
	$("#pelatesAdd").show();
});

$("#epeksergasia").click(function(){
	hideAll();
	$("#pelatesEditUpdate").show();
});

$("#diagrafi").click(function(){
	hideAll();
	$("#pelatesDelete").show();
});


function hideAll(){
	
		$("#pelatesEditUpdate").hide();
		$("#pelatesDelete").hide();
		$("#pelatesAdd").hide();
}

$("tr").click(function(){
	var a = $(this).closest('tr').find('td:first').text();

 $.ajax({
            type:"POST",
            url:"pelatisEdit",
            data:{p_id:a},
            success:function(data){
            var b = jQuery.parseJSON(data)
            $('input[name=p_id]').val(b.p_id);
            $('input[name=Onoma]').val(b.Onoma);
            $('input[name=Epitheto]').val(b.Epitheto);
            $('input[name=Onoma_Miteras]').val(b.Onoma_Miteras);
            $('input[name=Onoma_Patera]').val(b.Onoma_Patera);
            $('input[name=Epaggelma]').val(b.Epaggelma);
            $('input[name=Email]').val(b.Email);
            $('input[name=Tilefono_Oikias]').val(b.Tilefono_Oikias);
            $('input[name=Kinito_Tilefono]').val(b.Kinito_Tilefono);
            $('input[name=Dimos]').val(b.Dimos);
            $('input[name=Hmerominia_Gennisis]').val(b.Hmerominia_Gennisis);
            $('input[name=Diefthinsi]').val(b.Diefthinsi);
            $('input[name=Periferiaki_Enotita]').val(b.Periferiaki_Enotita);
            $('input[name=Periferia]').val(b.Periferia);
             //  alert(data);
             
             	
        }


            
        });

});

</script>


		


@stop



      
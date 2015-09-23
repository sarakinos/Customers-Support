<?php

class EmailController extends \BaseController {

	/**
	 * Display a listing of the resource.
	 *
	 * @return Response
	 */



	public function sendMail(){

		$emailList = Input::get('list');
		
$data = [ 'msg' => Input::get('message') ];

foreach ($emailList as $mailuser) {
    Mail::queue('email.sendMail', $data, function($message) use ($mailuser) {
        $message->to($mailuser, 'Bampis Sykovaridis')->subject('Γραφείο Παροχής Υπηρεσιών');
    });
}

return Redirect::to('/leitourgies');




	}


}

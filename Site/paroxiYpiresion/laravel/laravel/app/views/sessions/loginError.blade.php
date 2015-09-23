
@extends('layouts.default')

@section('content')

<div class="container">
    <div class="row">
        <div class="col-sm-6 col-md-4 col-md-offset-4">
            <h1 class="text-center login-title">Sign in</h1>
            <div class="account-wall">
                <img class="profile-img" src="https://lh5.googleusercontent.com/-b0-k99FZlyE/AAAAAAAAAAI/AAAAAAAAAAA/eu7opA4byxI/photo.jpg?sz=120"
                    alt="">
                <form class="form-signin" method="post" action="sessionStore">
                <input type="text" name="username" class="form-control" placeholder="Username" required autofocus autocomplete="off">
                <input type="password" name="password" class="form-control" placeholder="Password" required autocomplete="off">
                <button class="btn btn-lg btn-primary btn-block" type="submit">
                    Sign in</button>
                <label class="checkbox pull-left">
                   
                  
                </label>
                <span><h6 class="bg-danger">Δεν έχετε πρόσβαση στην εφαρμογή, επικοινωνήστε με τον διαχειρηστή του συστήματος</h6></span>
                </form>

            </div>
           
        </div>

    </div>

</div>



@stop
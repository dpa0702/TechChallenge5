import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  resposta: string = '';

  constructor(
    private spinnerService: NgxSpinnerService,
    private router: Router
  ){ }

  formLogin = new FormGroup({
  });

  onSubmit(): void {    
  }

  onClickButton(){
    this.spinnerService.show();
    setTimeout(() => {
      this.spinnerService.hide();
    }, 1000);
    
  }

}

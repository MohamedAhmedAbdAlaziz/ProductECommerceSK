import { Component } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import {
  faEye,
  faEyeSlash,
  faLock,
  faUser,
} from '@fortawesome/free-solid-svg-icons';
import ValidationForm from 'src/helpers/validateform';
import { AccountService } from '../account.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  returnUrl: string;
  type = 'password';
  isText = false;
  loginForm: FormGroup;
  constructor(
    private fb: FormBuilder,
    private accountService: AccountService,
    private router: Router,
    private activateRouter: ActivatedRoute
  ) {}
  ngOnInit(): void {
    this.returnUrl =
      this.activateRouter.snapshot.queryParams.returnUrl || '/shop';
    this.createLoginForm();
  }
  createLoginForm() {
    this.loginForm = new FormGroup({
      email: new FormControl('', [
        Validators.required,
        Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$'),
      ]),
      password: new FormControl('', Validators.required),
    });
  }
  hideShowPass() {
    this.isText = !this.isText;
    // this.eyeicon = this.isText ? faEye : faEyeSlash;
    this.type = this.isText ? 'text' : 'password';
  }
  onSubmit() {
    this.accountService.login(this.loginForm.value).subscribe(
      () => {
        this.router.navigateByUrl(this.returnUrl);
        console.log('succsed');
      },
      (error) => {
        console.log(error.error.message);
      }
    );
  }
}

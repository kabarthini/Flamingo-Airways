
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-payment',
  standalone: true,   
  imports: [CommonModule, ReactiveFormsModule, FormsModule],
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})

export class PaymentComponent implements OnInit {
  paymentForm: FormGroup;
  flight: any = null;
  total = 0;
  message = '';
  error = '';

  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.paymentForm = this.fb.group({
      flightId: ['', Validators.required],
      passengerName: ['', Validators.required],
      passengerCount: [1, [Validators.required, Validators.min(1)]],
      cardNumber: ['', Validators.required],
      expiry: ['', Validators.required],
      cvv: ['', Validators.required]
    });
  }

  ngOnInit() {  
    
    this.paymentForm.get('passengerCount')?.valueChanges.subscribe(() => this.updateTotal());
  }

  getFlightDetails() {
    const flightId = this.paymentForm.value.flightId;
    if (!flightId) {
      this.error = 'Please enter a flight ID';
      return;
    }

    this.http.get(`https://localhost:7137/api/payment/flight/${flightId}`).subscribe({
      next: (res) => {
        this.flight = res;
        this.error = '';
        this.message = '';
        this.updateTotal();
        console.log('flight object:', this.flight); 
      },
      error: (err) => {
        console.error(err);
        this.error = err?.error || 'Flight not found';
        this.flight = null;
        this.total = 0;
      }
    });
  }

  updateTotal() {
    const count = this.paymentForm.get('passengerCount')?.value || 0;
  
    const price = this.flight?.price ?? this.flight?.Price ?? 0;
    this.total = count * price;
  }


onPay() {
 
  if (!this.flight) {
    alert('Please search for a flight first.');
    return;
  }
  if (this.paymentForm.invalid) {
    alert('Please fill all required payment fields.');
    return;
  }

  const payload = {
    passengerName: this.paymentForm.value.passengerName,
    passengerCount: this.paymentForm.value.passengerCount,
    cardNumber: this.paymentForm.value.cardNumber,
    expiry: this.paymentForm.value.expiry,
    cvv: this.paymentForm.value.cvv
  };

 
  const flightIdToUse =
    this.flight?.flightID ??
    this.flight?.flightId ??
    this.flight?.id ??
    this.paymentForm.value.flightId;

  this.http.post(`https://localhost:7137/api/payment/pay/${flightIdToUse}`, payload)
    .subscribe({
      next: (res: any) => {
        
        const pnr = res?.pnr ?? res?.PNR ?? res?.Pnr ?? '-';
        const amount = res?.amount ?? res?.Amount ?? this.total ?? 0;

        
        alert(
          `✅ Payment Confirmed!\n\nPNR: ${pnr}\nAmount: ₹${amount}\n\nThank you for booking with Flamingo Airways.`
        );

     
        this.paymentForm.patchValue({
          passengerName: '',
          passengerCount: 1,
          cardNumber: '',
          expiry: '',
          cvv: ''
        });

        
        this.message = `Payment successful! PNR: ${pnr}`;
        this.error = '';
      },
      error: (err) => {
        const errMsg = (err && (err.error || err.message)) || 'Payment failed. Please try again.';
      
        alert(`⚠️ Payment failed:\n\n${errMsg}`);
        this.error = errMsg;
        this.message = '';
      }
    });
}

}

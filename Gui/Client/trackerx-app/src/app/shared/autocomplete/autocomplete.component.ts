import { CommonModule } from "@angular/common";
import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { Observable } from "rxjs";

@Component({
    standalone: true,
    imports: [ FormsModule, CommonModule ],
    selector: 'tx-autocomplete',
    templateUrl: './autocomplete.component.html',
    styleUrls: ['./autocomplete.component.css']
})
export class AutocompleteComponent implements OnInit {

    @Input() public value: string;
    @Input() public suggestions$: Observable<string[]>;
    @Output() onChangeEvent: EventEmitter<string> = new EventEmitter<string>()    

    public ngOnInit(): void {
        
    }

    public onChange(newValue: any): void {
        this.onChangeEvent.emit(newValue);
    }
}
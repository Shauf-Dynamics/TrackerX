export class ProposalView {
    public proposalId: number;
    public songName: string;
    public bandName: string;
    public albumName: string;
    public status: string;
    public message: string;
    public openedDate: Date;    
    public updatedDate: Date;    

    public constructor(init?:Partial<ProposalView>) {
        Object.assign(this, init);
    }
}

export class ProposalSearchModel {
    public songPattern: string;
    public status: string;
}